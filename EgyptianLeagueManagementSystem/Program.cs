using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EgyptianLeagueManagementSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcom to Egyption leaguge ---");
            while (true)
            {
                Console.WriteLine("--- Please Enter a number : ---");
                Console.WriteLine("1 -PLAYERS -");
                Console.WriteLine("2 -TEAMS   -");
                Console.WriteLine("3 -MATCHES -");
                Console.WriteLine("4 -EXIT    -");


                int num = int.Parse(Console.ReadLine());

                if (num == 1)
                {
                    while (true)
                    {

                        Console.WriteLine("--- Please Enter a number : ---");
                        Console.WriteLine("1- Insert a New Player -");
                        Console.WriteLine("2- Display Player Information -");
                        Console.WriteLine("3- Display All Players Information -");
                        Console.WriteLine("4- Update Player Information -");
                        Console.WriteLine("5- Search for a Player - ");
                        Console.WriteLine("6- Back to Main menu");

                        Player p = new Player();
                        int choose = int.Parse(Console.ReadLine());
                        if (choose == 6)
                            break;
                        switch (choose)
                        {
                            case 1:
                                {
                                    p.insertPlayer();
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Enter the id of the player");
                                    int id = int.Parse(Console.ReadLine());
                                    p.DisplayPlayerInfo(id);
                                    break;
                                }
                            case 3:
                                {
                                    Player.DisplayAllPlayerList();
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Enter the name of the player");
                                    string name = Console.ReadLine();
                                    Player.UpdateInfo(name);
                                    break;
                                }
                            case 5:
                                {
                                    Console.WriteLine("Enter the name of the player");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Enter the id of the player");
                                    int id = int.Parse(Console.ReadLine());
                                    Player.SearchForPlayer(id, name);
                                    break;
                                }

                        }
                    }
                }
                else if (num == 2)
                {
                    while (true)
                    {

                        Console.WriteLine("--- Please Enter a number : ---");
                        Console.WriteLine("1- Insert a New Team -");
                        Console.WriteLine("2- Update Team Information -");
                        Console.WriteLine("3- Display Team Information -");
                        Console.WriteLine("4- Display Team Players -");
                        Console.WriteLine("5- Display All Teams -");
                        Console.WriteLine("6- Display Detail Score - ");
                        Console.WriteLine("7- Display Held Matches - ");
                        Console.WriteLine("8- Display To Be Held Matches - ");
                        Console.WriteLine("9- Display Matches With Details - ");
                        Console.WriteLine("10- Search for a Team - ");
                        Console.WriteLine("11- Back to Main menu");
                        
                        int choose = int.Parse(Console.ReadLine());
                        if (choose == 11)
                            break;
                        switch (choose)
                        {
                            case 1:
                                {
                                    Team.insertTeam();
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Enter the id of the team you want to update :");
                                    int id = int.Parse(Console.ReadLine());
                                    Team.UpdateTeamInList(id);
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Enter the id of the team :");
                                    int id = int.Parse(Console.ReadLine());
                                    Team.displayInfoTeam(id);
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Enter the name of the team :");
                                    string name = Console.ReadLine();
                                    Team.DisplayTeamPlayers(name);
                                    break;
                                }
                            case 5:
                                {
                                    Team.DisplayAllTeamList();
                                    break;
                                }
                            case 6:
                                {
                                    Console.WriteLine("Enter the name of the team :");
                                    string name = Console.ReadLine();
                                    Team.DisplayDetailScore(name);
                                    break;
                                }
                            case 7:
                                {
                                    Console.WriteLine("Enter the name of the team :");
                                    string name = Console.ReadLine();
                                    Team.DisplayHeldMatches(name);
                                    break;
                                }
                            case 8:
                                {
                                    Console.WriteLine("Enter the name of the team :");
                                    string name = Console.ReadLine();
                                    Team.DisplayToBeHeldMatches(name);
                                    break;
                                }
                            case 9:
                                {
                                    Console.WriteLine("Enter the name of the team :");
                                    string name = Console.ReadLine();
                                    Team.DisplayMatchesWithDetails(name);
                                    break;
                                }
                            case 10:
                                {
                                    Console.WriteLine("Enter the name of the team :");
                                    string name = Console.ReadLine();
                                    Team.searchByName(name);
                                    break;
                                }

                        }
                    }
                }
                else if (num == 3)
                {
                    while (true)
                    {

                        Console.WriteLine("--- Please Enter a number : ---");
                        Console.WriteLine("1- Insert a New Match -");
                        Console.WriteLine("2- Display Match Details -");
                        Console.WriteLine("3- Update Match  -");
                        Console.WriteLine("4- Display All Matches -");
                        Console.WriteLine("5- Back to Main menu");

                        Match m = new Match();
                        int choose = int.Parse(Console.ReadLine());
                        if (choose == 5)
                            break;
                        switch (choose)
                        {
                            case 1:
                                {
                                    m.Match_Information();
                                    break;
                                }
                            case 2:
                                {
                                    //m.Match_Details();
                                    Console.WriteLine(m.ToString());
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Enter the id of the match you want to update :");
                                    int id = int.Parse(Console.ReadLine());
                                    Match.Update_Match(id);
                                    break;
                                }
                            case 4:
                                {
                                    Match.Held_To_be_Held();
                                    break;
                                }
                       
                        }
                    }
                }
                else if (num == 4)
                {
                    break;
                }

            }
            
               
          
        }
    }
}