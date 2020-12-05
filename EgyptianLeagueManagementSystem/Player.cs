using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EgyptianLeagueManagementSystem
{
    enum PlayerRole
    {
        Forward,
        Midfielder,
        Defender,
        Goalkeeper
    }
    class Player
    {
        public static List<Player> playersName = new List<Player>();
        private string name;
        private int number;
        private string team;
        private PlayerRole role;
        private int age;
        private int score;
        private int rank;
        public Player() { 
        }

        public Player(int id, string _name, string teamname, string pr, int _age, int _score, int _rank)
        {
            number = id;
            name = _name;
            team = teamname;
            switch (pr) {
                case "Forward":
                    role = PlayerRole.Forward;
                    break;
                case "Defender":
                    role = PlayerRole.Defender;
                    break;
                case "Goalkeeper":
                    role = PlayerRole.Goalkeeper;
                    break;
                case "Midfielder":
                    role = PlayerRole.Midfielder;
                    break;
            }

            age = _age;
            score = _score;
            rank = _rank;


        }
        public void setName(string _name)
        {
            name = _name;
        }
        public void setNumber(int _number)
        {
            number = _number;
        }
        public void setTeam(string _team)
        {
            team = _team;
        }
        public void setRole(PlayerRole _role)
        {
            role = _role;
        }
        public void setAge(int _age)
        {
            age = _age;
        }
        public void setScore(int _score)
        {
            score = _score;
        }
        public void setRank(int _rank)
        {
            rank = _rank;
        }

        public string getName()
        {
            return name;
        }
        public int getNumber()
        {
            return number;
        }
        public string getTeam()
        {
            return team;
        }
        public PlayerRole getRole()
        {
            return role;
        }
        public int getAge()
        {
            return age;
        }
        public int getScore()
        {
            return score;
        }
        public int getRank()
        {
            return rank;
        }
        public void insertPlayer()
        {
            Player p = new Player();
            Console.WriteLine("Enter name of player:");
            p.setName(Console.ReadLine());
            Console.WriteLine("Enter number of this player:");
            p.setNumber(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter age for this player :");
            p.setAge(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter name of the team of this player :");
            p.setTeam(Console.ReadLine());
            Console.WriteLine("Enter score for this player :");
            p.setScore(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter rank for this player :");
            p.setRank(int.Parse(Console.ReadLine()));
            Console.WriteLine("Choose role where   Forward:1 || Midfielder:2 || Defender:3 || Goalkeeper:4");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    p.setRole(PlayerRole.Forward); break;
                case 2:
                    p.setRole(PlayerRole.Midfielder); break;
                case 3:
                    p.setRole(PlayerRole.Defender); break;
                case 4:
                    p.setRole(PlayerRole.Goalkeeper); break;
            }
            Console.WriteLine("Team player have been successfully entered...");
            Player.insertplayertofile(p);
        }
        public override string ToString()
        {
            return string.Format(
                "Player's Info:\n" +
                "Player Name: {0}\n" +
                "Player Number: {1}\n" +
                "Player Team: {2}\n" +
                "Player Age: {3}\n" +
                "Player Role: {4}\n" +
                "Player Score: {5}\n" +
                "Player Rank: {6}"
                ,name, number, team, age, role, score, rank
                );
        }
        public void DisplayPlayerInfo(int id)
        {
            playersName = ReadListofplayersfromfile();

            foreach (Player item in playersName)
            {
                if (item.getNumber() == id)
                {
                    Console.WriteLine("Player's Info:");
                    Console.WriteLine("Player Name: {0}", item.name);
                    Console.WriteLine("Player Number: {0}", item.number);
                    Console.WriteLine("Player Team: {0}", item.team);
                    Console.WriteLine("Player Age: {0}", item.age);
                    Console.WriteLine("Player Role: {0}", item.role);
                    Console.WriteLine("Player Score: {0}", item.score);
                    Console.WriteLine("Player Rank: {0}", item.rank);
                }

            }
        }

        public static void DisplayAllPlayerList() 
        {
            playersName = ReadListofplayersfromfile();
            foreach (Player t in playersName)
                //t.DisplayPlayerInfo(t.getNumber());
                Console.WriteLine(t.ToString());
        }
       
        public static void UpdateInfo(string _name)
        {
            playersName = ReadListofplayersfromfile();
           
            for(int i = 0; i < playersName.Count(); i++)
            {
                if (playersName[i].getName() == _name)
                {
                    Console.WriteLine("Choose, If you want to update player's name : enter 0 || name team : enter 1 || player's age : enter 2 || player's score : enter 3 || player's number : enter 4 || player's rank : enter 5");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 0:
                            Console.WriteLine("Enter new player's name : ");
                            playersName[i].setName(Console.ReadLine());
                            break;
                        case 1:
                            Console.WriteLine("Enter new name of team : ");
                            playersName[i].setTeam(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Enter new player's age : ");
                            playersName[i].setAge(int.Parse(Console.ReadLine()));
                            break;
                        case 3:
                            Console.WriteLine("Enter new player's score : ");
                            playersName[i].setScore(int.Parse(Console.ReadLine()));
                            break;
                        case 4:
                            Console.WriteLine("Enter new player's number : ");
                            playersName[i].setNumber(int.Parse(Console.ReadLine()));
                            break;
                        case 5:
                            Console.WriteLine("Enter new player's rank : ");
                            playersName[i].setRank(int.Parse(Console.ReadLine()));
                            break;
                    }
                }
                updateplayeronfile(playersName);
            }
           
         
        }

        public static void SearchForPlayer(int _number, string _name)
        {
            playersName = ReadListofplayersfromfile();
            bool flag = true;
            foreach (Player item in playersName)
            {
                if (item.getNumber() == _number && item.getName() == _name )
                {
                    Console.WriteLine("Player Found!");
                    //item.DisplayPlayerInfo(item.getNumber());
                    Console.WriteLine(item.ToString());
                    flag=false;
                    break;
                }
            }
            if (flag) 
                Console.WriteLine("Player Not Found!");   
        }

        public static void insertplayertofile(Player p)
        {
            StreamWriter writer = File.AppendText("players.txt");
            string line = string.Format(p.number+"-"+p.name +"-"+ p.team +"-"+p.role+"-"+p.age+"-"+p.score+"-"+p.rank);
            writer.WriteLine(line);
            writer.Close();
        }
        public static void updateplayeronfile(List<Player> list)
        {
            File.WriteAllText("players.txt", string.Empty);
            StreamWriter writer = File.AppendText("players.txt");
            for (int i = 0; i < list.Count(); i++)
            {
                string line = string.Format(list[i].number.ToString()+"-"+list[i].name + "-" + list[i].team
                    +"-" + list[i].role.ToString() + "-"+list[i].age + "-" +list[i].score + "-" + list[i].rank);
                writer.WriteLine(line);
               
            }
            writer.Close();
        }
        public static List<Player> ReadListofplayersfromfile()
        {

            List<Player> list = new List<Player>();
            StreamReader Textfile = new StreamReader("players.txt");
            string line;

            while ((line = Textfile.ReadLine()) != null)
            {
                string[] s = line.Split('-');
                Player p = new Player(int.Parse(s[0]), s[1], s[2],s[3],int.Parse(s[4]), int.Parse(s[5]), int.Parse(s[6]));
                list.Add(p);
            }

            Textfile.Close();
           
            return list;

        }


    }
}