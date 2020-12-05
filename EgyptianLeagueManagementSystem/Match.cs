using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EgyptianLeagueManagementSystem
{
    class Match
    {
        //public static List<Match> Listofmatches;

        //Variables

        private int ID;
        private static int day;
        private static int month;
        private static int year;
        private DateTime Date;
        private List<string> Match_Teams = new List<string>();  //List of teams
        private string Match_Referee;
        private string Team1_Score;
        private string Team2_Score;
        private string Stadium_Name;

        private string winnerandloser;



        //Constructor
        public Match()
        {

        }
        public Match(int id, DateTime dt, string team1, string s1, string team2, string s2, string stad, string mr)
        {
            ID = id;
            Date = dt;
            Match_Teams.Add(team1);
            Team1_Score = s1;
            Match_Teams.Add(team2);
            Team2_Score = s2;
            Stadium_Name = stad;
            Match_Referee = mr;

        }

        //Setter and Getters
        public void set_ID(int id)
        {
            ID = id;
        }

        public int get_ID()
        {
            return ID;
        }

        public void set_Date(int dayy, int monthh, int yearr)
        {
            day = dayy;
            month = monthh;
            year = yearr;
            Date = new DateTime(year, month, day);
        }

        public DateTime get_Date()
        {
            return Date;
        }

        public void set_Match_Teams(List<string> list)
        {
            Match_Teams = list;
        }

        public List<string> get_Match_Teams()
        {
            return Match_Teams;
        }

        public void set_Match_Referee(string referee_name)
        {
            Match_Referee = referee_name;
        }

        public string get_Match_Referee()
        {
            return Match_Referee;
        }

        public void set_Score(string score1, string score2)
        {
            Team1_Score = score1;
            Team2_Score = score2;
        }

        public string get_Score1()
        {
            return Team1_Score;
        }
        public string get_Score2()
        {
            return Team2_Score;
        }

        public void set_Stadium_Name(string Stad_Name)
        {
            Stadium_Name = Stad_Name;
        }

        public string get_Stadium_Name()
        {
            return Stadium_Name;
        }


        //Functions
        //Get Information
        public void Match_Information()
        {

            DateTime currentdate = DateTime.Now;

            Console.WriteLine("Please enter the Match ID: ");
            ID = int.Parse(Console.ReadLine());


            Console.WriteLine("Please enter the Match Date: ");
            Console.WriteLine("Please enter the Day: ");
            day = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Month(in numbers): ");
            month = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Year: ");
            year = int.Parse(Console.ReadLine());

            Date = new DateTime(year, month, day);
            Console.WriteLine("Please enter the Match Teams: ");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Please enter Team #{0}: ", i + 1);
                string name = Console.ReadLine();
                Match_Teams.Add(name);
            }

            Console.WriteLine("Please enter the Match Referee: ");
            Match_Referee = Console.ReadLine();


            Console.WriteLine("Please enter the Stadium Name: ");
            Stadium_Name = Console.ReadLine();

            if (Date.Date < currentdate.Date)
            {
                Console.WriteLine("Please enter the Match Score: ");
                Console.WriteLine("Team #1 Score: ");
                Team1_Score = Console.ReadLine();
                Console.WriteLine("Team #2 Score: ");
                Team2_Score = Console.ReadLine();
                //UpdateScore(Match_Teams[0], int.Parse(Team1_Score), Match_Teams[1], int.Parse(Team2_Score));

            }

            else
            {
                Team1_Score = null;
                Team2_Score = null;


            }


            InsertMatchToFile();


        }
        public override string ToString()
        {
            string matches = "";
            for (int i = 0; i < Match_Teams.Count; i++)
            {
                matches+=("Team #" + (i + 1) + ": " + Match_Teams[i] + "\n");
            }
            return string.Format(
                "Match Date: {0}\n" +
                "Match Teams:\n" +
                "{1}" +
                "Match Referee: {2}\n" +
                "Match Stadium: {3}\n" +
                "Match Score:\n" +
                "Team 1 Score: {4}\n" +
                "Team 2 Score: {5}"
                ,Date, matches, Match_Referee, Stadium_Name, Team1_Score, Team2_Score);
        }
        //Match Details
        /*public void Match_Details()
        {

            Console.WriteLine("Match Date: " + get_Date() + "\n");

            Console.WriteLine("Match Teams: ");
            for (int i = 0; i < Match_Teams.Count; i++)
            {
                Console.WriteLine("Team #{0}: {1}", i + 1, Match_Teams[i]);
            }

            Console.WriteLine("Match Referee: " + get_Match_Referee() + "\n");

            Console.WriteLine("Match Stadium: " + get_Stadium_Name() + "\n");

            Console.WriteLine("Match Score: ");
            Console.WriteLine("Team 1 Score: " + get_Score1());
            Console.WriteLine("Team 2 Score: " + get_Score2());


        }
        */
        //Update Match
        public static void Update_Match(int matchID)
        {

            List<Match> listofmatches = ReadListfromfile();
            for (int i = 0; i < listofmatches.Count(); i++)
            {
                if (listofmatches[i].get_ID() == matchID)
                {

                    bool again = true;
                    while (again)
                    {
                        Console.WriteLine("To change the match's date (Press 1), \n To change the match's Teams (Press 2), \n To change the match's Referee (Press 3), \n To change the match's score (Press 4), \n To change the stadium name (Press 5): ");
                        int ans = int.Parse(Console.ReadLine());
                        if (ans == 1)
                        {
                            Console.WriteLine("Enter the new date: ");
                            Console.WriteLine("Enter the day (1-31): ");
                            day = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the month (1-12): ");
                            month = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the year (4 digits): ");
                            year = int.Parse(Console.ReadLine());

                            listofmatches[i].set_Date(year, month, day);
                            again = false;
                        }
                        else if (ans == 2)
                        {
                            Console.WriteLine("Enter the new Teams: ");
                            Console.WriteLine("Enter Team 1: ");
                            listofmatches[i].Match_Teams[0] = Console.ReadLine();
                            Console.WriteLine("Enter Team 2: ");
                            listofmatches[i].Match_Teams[1] = Console.ReadLine();
                            again = false;
                        }
                        else if (ans == 3)
                        {
                            Console.WriteLine("Enter the match's referee: ");
                            listofmatches[i].Match_Referee = Console.ReadLine();
                            again = false;
                        }
                        else if (ans == 4)
                        {
                            Console.WriteLine("Enter the match's score: ");
                            Console.WriteLine("Team #1 score: ");
                            listofmatches[i].Team1_Score = Console.ReadLine();
                            Console.WriteLine("Team #2 score: ");
                            listofmatches[i].Team2_Score = Console.ReadLine();
                            again = false;
                        }
                        else if (ans == 5)
                        {
                            Console.WriteLine("Enter the Stadium Name: ");
                            listofmatches[i].Stadium_Name = Console.ReadLine();
                            again = false;
                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid number please try again!");
                            continue;
                        }
                    }
                    UpdateFile(listofmatches[i]);

                }
            }

        }

        //Held and To Be Held Matches
        public static void Held_To_be_Held()
        {
            List<Match> all_match = ReadListfromfile();

            List<Match> held = new List<Match>();
            List<Match> tobe_held = new List<Match>();

            DateTime currentdate = DateTime.Now;

            for (int i = 0; i < all_match.Count; i++)
            {
                if (all_match[i].get_Date() < currentdate)
                {
                    held.Add(all_match[i]);

                }

                else
                {
                    tobe_held.Add(all_match[i]);
                }
            }

            Console.WriteLine("Held Matches: ");

            for (int i = 0; i < held.Count; i++)
            {
                //held[i].Match_Details();
                Console.WriteLine(held[i].ToString());
            }

            Console.WriteLine("To Be Held Matches: ");

            for (int i = 0; i < tobe_held.Count; i++)
            {
                //tobe_held[i].Match_Details();
                Console.WriteLine(tobe_held[i].ToString());
            }

        }

        //Winner and Loser
        public string WinnerandLoser()
        {

            if (int.Parse(get_Score1()) > int.Parse(get_Score2()))
            {
                winnerandloser = Match_Teams[0] + "/" + get_Score1() + "//" + Match_Teams[1] + "/" + get_Score2();
                return winnerandloser;

            }
            else if (int.Parse(get_Score1()) < int.Parse(get_Score2()))
            {
                winnerandloser = Match_Teams[1] + "/" + get_Score2() + "//" + Match_Teams[0] + "/" + get_Score1();
                return winnerandloser;
            }
            else
            {
                winnerandloser = "A tie";
                return winnerandloser;
            }

        }

        public void InsertMatchToFile()
        {

            StreamWriter writer = File.AppendText("match.txt");
            if (Team1_Score == null && Team2_Score == null)
            {
                string line = string.Format(this.ID + "-" + this.Date.ToString() + "-" + this.Match_Teams[0] + "-" + 0 + "-" +
                    this.Match_Teams[1] + "-" + 0 + "-" + this.Stadium_Name + "-" + this.Match_Referee);
                writer.WriteLine(line);
            }
            else
            {
                string line = string.Format(this.ID + "-" + this.Date.ToString() + "-" + this.Match_Teams[0] + "-" + Team1_Score + "-" +
                    this.Match_Teams[1] + "-" + Team2_Score + "-" + this.Stadium_Name + "-" + this.Match_Referee);
                writer.WriteLine(line);
            }
            writer.Close();
        }
        public static void UpdateFile(Match m)
        {
            string newline = string.Format(m.ID + "-" + m.Date.ToString() + "-" + m.Match_Teams[0] + "-" + 0 + "-" +
                    m.Match_Teams[1] + "-" + 0 + "-" + m.Stadium_Name + "-" + m.Match_Referee);

            List<string> L = File.ReadAllLines("match.txt").ToList();
            int index = 0;
            foreach (var l in L)
            {
                if (int.Parse(l[0].ToString()) == m.ID)
                {
                    L.RemoveAt(index);
                    L.Add(newline);
                    break;
                }
                index++;
            }
            File.WriteAllLines("match.txt", L.ToArray());
        }
        public static List<Match> ReadListfromfile()
        {

            List<Match> list = new List<Match>();
            StreamReader Textfile = new StreamReader("match.txt");
            string line;

            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                Match m = new Match(int.Parse(s[0]), DateTime.Parse(s[1]).Date, s[2], s[3], s[4], s[5], s[6], s[7]);
                list.Add(m);

            }

            Textfile.Close();
            return list;

        }

       /* public void UpdateScore(string t1, int s1, string t2, int s2)
        {

        }*/

    }
}
