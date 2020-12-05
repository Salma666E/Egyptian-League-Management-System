using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EgyptianLeagueManagementSystem
{
    class Team
    {
        private int id;
        private string name;
        private string captain;
        private int total_score;
        public static List<Team> teams = new List<Team>();
        public static List<Match> matchs = new List<Match>();
        private static List<string> players = new List<string>();

        public Team() { }
        public Team(int _id, string _name, string _captain, int _score)
        {
            this.id = _id;
            this.name = _name;
            this.captain = _captain;
            this.total_score = _score;

        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setCaptain(string _captain)
        {
            this.captain = _captain;
        }
        public string getCaptain()
        {
            return this.captain;
        }
        public void setTotal_score(int total_score)
        {
            this.total_score = total_score;
        }
        public int getTotal_score()
        {
            return total_score;
        }
        public void setPlayers(string p)
        {
            players.Add(p);
        }
        public List<string> getPlayers()
        {
            return players;
        }
        public void setMatchs(Match m)
        {
            matchs.Add(m);
        }
        public List<Match> getMatchs()
        {
            return matchs;
        }
        //Functionality
        public static void insertTeam()
        {
            Team Te = new Team();

            Console.WriteLine("Enter name of team:");
            Te.setName(Console.ReadLine());

            Console.WriteLine("Enter id of this team:");
            Te.setId(int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter captain for this team :");
            Te.setCaptain(Console.ReadLine());

            Console.WriteLine("Enter total_score of this team:");
            Te.setTotal_score(int.Parse(Console.ReadLine()));

            teams.Add(Te);
            Console.WriteLine("Team items have been successfully entered...");
            InsertTeamToFile(Te);
        }
        public static void displayInfoTeam(int id)
        {
            StreamReader Textfile = new StreamReader("teams.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split(' ');
                if (int.Parse(s[0]) == id)
                {
                    Console.WriteLine("Name of team: {0}", s[1]);
                    Console.WriteLine("Id of this team: {0}", s[0]);
                    Console.WriteLine("Total_score for this team: {0}", s[3]);
                    Console.WriteLine("Name of it's captain is: {0}", s[2]);
                    Team.playerInTeam(s[1]);
                    Team.matchByTeam(s[1]);
                }
            }
            Textfile.Close();
            Console.WriteLine("Team items have been successfully displayed...");
        }
        public static void playerInTeam(string nameT){
            int count = 0;
            StreamReader Textfile = new StreamReader("players.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                if (s[2] == nameT)
                {
                    count++;
                    Console.WriteLine("Name of Player{0} is {1}", count, s[1]);
                }
            }
            Textfile.Close();
        }
        public static void matchByTeam(string nameT) {
            int count = 0;
            StreamReader Textfile = new StreamReader("match.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                if (s[2] == nameT || s[2] == nameT)
                {
                    count++;
                    Console.WriteLine("Date of match{0} is {1}", count, s[1]);
                }
            }
            Textfile.Close();
        }
        public static void DisplayAllTeamList()
        {
            StreamReader Textfile = new StreamReader("teams.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split(' ');
                Console.WriteLine("Name of team: {0}", s[1]);
                Console.WriteLine("Id of this team: {0}", s[0]);
                Console.WriteLine("Total_score for this team: {0}", s[3]);
                Console.WriteLine("Name of it's captain is: {0}", s[2]);
                Team.playerInTeam(s[1]);
                Team.matchByTeam(s[1]);
            }
            Textfile.Close();
        }
        public static void searchById(int id)
        {
            bool flag = true;
            StreamReader Textfile = new StreamReader("teams.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split(' ');
                if (int.Parse(s[0]) == id)
                {
                    Console.WriteLine("Well Done that there team by this id ");
                    flag = false;
                    break;
                }
            }
            if (flag)
                Console.WriteLine("Sorry, There is no team has id={0}", id);
            Textfile.Close();

        }
        public static void searchByName(string name)
        {
            bool flag = true;
            StreamReader Textfile = new StreamReader("teams.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split(' ');
                if (s[1] == name)
                {
                    Console.WriteLine("Well Done that there team by this name:{0}",name);
                    flag = false;
                    break;
                }
            }
            if (flag)
                Console.WriteLine("Sorry, There is no team has name:{0}", name);
            Textfile.Close();

        }
        public static void InsertTeamToFile(Team T)
        {
            string line = String.Format(T.id.ToString() + " " + T.name + " " + T.captain + " " + T.total_score.ToString());
            StreamWriter writer = File.AppendText("teams.txt");
            writer.WriteLine(line);
            writer.Close();
        }
        public static void UpdateTeamInList( int id)
        {
            Console.WriteLine("If you want to update the name of this team enter 0 and if update the name captain of this enter 1");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new value to update");
            string upValue = Console.ReadLine();
            teams = ReadListofTeamsfromfile();
            for (int i = 0; i < teams.Count(); i++)
                if (id == teams[i].getId())
                {
                    if (t == 0)
                        teams[i].setName(upValue);
                    else if (t == 1)
                        teams[i].setCaptain(upValue);
                    else
                        Console.WriteLine("Sorry, Wrong choice");
                    break;
                }
            updateTeamonfile(teams);
        }
        public static void updateTeamonfile(List<Team> list)
        {
            File.WriteAllText("teams.txt", string.Empty);
            StreamWriter writer = File.AppendText("teams.txt");
            for (int i = 0; i < list.Count(); i++)
            {
                string line = string.Format(list[i].getId().ToString() + " " + list[i].getName() + " " + list[i].getCaptain()
                    + " " + list[i].getTotal_score());
                writer.WriteLine(line);
            }
            writer.Close();
        }
        public static List<Team> ReadListofTeamsfromfile()
        {
            List<Team> list = new List<Team>();
            StreamReader Textfile = new StreamReader("teams.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split(' ');
                Team p = new Team(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]));
                list.Add(p);
            }
            Textfile.Close();
            return list;
        }
        public static void DisplayTeamPlayers(string Teamname)
        {
            StreamReader Textfile = new StreamReader("players.txt");
            string line;

            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                if (s[2] == Teamname)
                    Console.WriteLine(s[1]);
            }

            Textfile.Close();
        }
        public static void DisplayDetailScore(string Teamname)
        {
            StreamReader Textfile = new StreamReader("match.txt");
            string line;
            int Score = 0;
            while ((line = Textfile.ReadLine()) != null)
            {

                string[] s = line.Split('-');
                if (s[2] == Teamname)
                {
                    if (int.Parse(s[3]) > int.Parse(s[5]))
                    {
                        Console.WriteLine(Teamname + " - " + s[4]);
                        Console.WriteLine(s[3] + " - " + s[5]);

                        Score += 3;
                    }
                    if (int.Parse(s[3]) < int.Parse(s[5]))
                    {
                        Console.WriteLine(Teamname + " - " + s[4]);
                        Console.WriteLine(s[3] + " - " + s[5]);
                    }
                    if (int.Parse(s[3]) == int.Parse(s[5]))
                    {
                        Console.WriteLine(Teamname + " - " + s[4]);
                        Console.WriteLine(s[3] + " - " + s[5]);
                        Score += 1;
                    }

                }
                if (s[4] == Teamname)
                {
                    if (int.Parse(s[5]) > int.Parse(s[3]))
                    {
                        Console.WriteLine(Teamname + " - " + s[2]);
                        Console.WriteLine(s[5] + " - " + s[3]);
                        Score += 3;
                    }
                    if (int.Parse(s[5]) < int.Parse(s[3]))
                    {
                        Console.WriteLine(Teamname + " - " + s[2]);
                        Console.WriteLine(s[5] + " - " + s[3]);
                    }
                    if (int.Parse(s[5]) == int.Parse(s[3]))
                    {
                        Console.WriteLine(Teamname + " - " + s[2]);
                        Console.WriteLine(s[5] + " - " + s[3]);
                        Score += 1;
                    }
                }
            }

            Console.WriteLine("Total Score = " + Score);
            Textfile.Close();

        }
        public static void DisplayHeldMatches(string teamname)
        {
            StreamReader Textfile = new StreamReader("match.txt");
            string line;
            Console.WriteLine("The Held Matches :");

            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                if (s[2] == teamname)
                {
                    if (DateTime.Parse(s[1]).Date < DateTime.Now.Date)
                    {
                        Console.WriteLine("Date of " + s[1]);
                        Console.WriteLine(teamname + " - " + s[4]);
                        Console.WriteLine(s[3] + " - " + s[5]);
                    }
                }
                if (s[4] == teamname)
                {
                    if (DateTime.Parse(s[1]).Date < DateTime.Now.Date)
                    {
                        Console.WriteLine("Date of " + s[1]);
                        Console.WriteLine(teamname + " - " + s[2]);
                        Console.WriteLine(s[5] + " - " + s[3]);
                    }
                }
            }
            Textfile.Close();
        }
        public static void DisplayToBeHeldMatches(string teamname)
        {
            StreamReader Textfile = new StreamReader("match.txt");
            string line;
            Console.WriteLine("To Be Held Matches :");
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                if (s[2] == teamname)
                {
                    if (DateTime.Parse(s[1]).Date > DateTime.Now.Date)
                    {
                        Console.WriteLine("Date of " + s[1]);
                        Console.WriteLine(teamname + " - " + s[4]);
                    }
                }
                if (s[4] == teamname)
                {
                    if (DateTime.Parse(s[1]).Date > DateTime.Now.Date)
                    {
                        Console.WriteLine("Date of " + s[1]);
                        Console.WriteLine(teamname + " - " + s[2]);
                    }
                }
            }
            Textfile.Close();
        }
        public static void DisplayMatchesWithDetails(string teamname)
        {
            StreamReader Textfile = new StreamReader("match.txt");
            string line;
            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                if (s[2] == teamname || s[4] == teamname)
                {
                    Console.WriteLine(s[2] + " - " + s[4]);
                    Console.WriteLine("match id = " + s[0] + " Date of " + s[1]);
                    Console.WriteLine("Stadium Name is :" + s[6] + " Match Referee is : " + s[7]);
                }
            }
            Textfile.Close();
        }
    }
}