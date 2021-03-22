using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlayerFactionSystemFinder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string ParentFactionId;

            // Get Faction Name
            Console.WriteLine("Please enter the EliteBGS Faction ID.  This will default to the Fatherhood if left blank");
            string input = Console.ReadLine();
            _ = string.IsNullOrEmpty(input) ? ParentFactionId = "5ae4bfccd1b6a37c3c947ddc" : ParentFactionId = input;

            List<EddbModel> AllFactions;
            List<KeyValuePair<string, string>> EmptySystemsList = new List<KeyValuePair<string, string>>();

            Console.WriteLine("Supply path to EDDB Factions file.  Leaving this blank will download this information for this session only and may take some time.  You can download this from https://eddb.io/archive/v6/factions.json.");
            string EddbLocation = Console.ReadLine();

            if (string.IsNullOrEmpty(EddbLocation))
            {
                Console.WriteLine("Downloading faction list from EDDB, this may take a moment...");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"https://eddb.io");
                    client.DefaultRequestHeaders.Add("User-Agent", "PlayerFactionSystemFinder");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync($"archive/v6/factions.json").Result;
                    response.EnsureSuccessStatusCode();
                    AllFactions = JsonConvert.DeserializeObject<List<EddbModel>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            else
            {
                using StreamReader file = File.OpenText(EddbLocation);
                AllFactions = JsonConvert.DeserializeObject<List<EddbModel>>(file.ReadToEnd());
            }

            Welcome ParentSystem;

            Console.WriteLine("Faction List Done.. Getting list of systems for target faction...");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://elitebgs.app");
                client.DefaultRequestHeaders.Add("User-Agent", "PlayerFactionSystemFinder");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"api/ebgs/v5/factions?id={ParentFactionId}").Result;
                response.EnsureSuccessStatusCode();
                ParentSystem = JsonConvert.DeserializeObject<Welcome>(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine("Done.. Ready to perform search, this will take some time depending on the size of the target faction.  This is to prevent abuse of the EliteBGS API which this makes use of.  Press any key when you're ready to continue...");
                Console.ReadKey();
                foreach (FactionPresence searchSystem in ParentSystem.Docs[0].FactionPresence)
                {
                    Console.WriteLine($"Performing search on {searchSystem.SystemName}");
                    var CubeResponse = client.GetAsync($"api/ebgs/v5/systems?referenceSystemId={searchSystem.SystemId}").Result;
                    response.EnsureSuccessStatusCode();
                    SystemWelcome CheckSystemResponse = JsonConvert.DeserializeObject<SystemWelcome>(CubeResponse.Content.ReadAsStringAsync().Result);

                    bool systemEmpty;
                    int totalPages = CheckSystemResponse.Pages;

                    for (int page = 1; page <= totalPages; page++)
                    {
                        if (page > 1)
                        {
                            CubeResponse = client.GetAsync($"api/ebgs/v5/systems?referenceSystemId={searchSystem.SystemId}&page={page}").Result;
                            response.EnsureSuccessStatusCode();
                            CheckSystemResponse = JsonConvert.DeserializeObject<SystemWelcome>(CubeResponse.Content.ReadAsStringAsync().Result);
                        }


                        foreach (SystemDoc CheckSystem in CheckSystemResponse.Docs)
                        {
                            systemEmpty = true;
                            if (CheckSystem.Factions != null)
                            {
                                foreach (FactionElement faction in CheckSystem.Factions)
                                {
                                    if (AllFactions.Where(a => a.Name.Equals(faction.Name) && a.IsPlayerFaction.Value == true).Count() > 0)
                                    {
                                        systemEmpty = false;
                                    }
                                }
                            }
                            if (systemEmpty && EmptySystemsList.Where(a => a.Key.Equals(CheckSystem.Name)).Count() == 0)
                            {
                                EmptySystemsList.Add(new KeyValuePair<string, string>(CheckSystem.Name, CheckSystem.Id));
                            }
                        }

                        await Task.Delay(2000);
                    }
                }
            }

            if (EmptySystemsList.Count() > 0)
            {
                Console.WriteLine("The Following systems in the multicube of influence do not contain a player faction...");
                foreach (var emptySystem in EmptySystemsList)
                {
                    Console.WriteLine($">{emptySystem.Key} - https://elitebgs.app/system/{emptySystem.Value}");
                }
            }

            Console.ReadKey();
            return;
        }
    }
}
