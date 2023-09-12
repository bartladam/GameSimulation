using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    /// <summary>
    /// Place where match between teams can starts
    /// </summary>
    internal class Arena
    {
        /// <summary>
        /// Arena impose team for match
        /// </summary>
        public Team blue;
        /// <summary>
        /// Arena impose team for match
        /// </summary>
        public Team red;
        /// <summary>
        /// Random bot or player from your/enemy team is attack
        /// </summary>
        Random playerAttack;
        public Arena(Team blue, Team red)
        {
            this.blue = blue;
            this.red = red;
            playerAttack = new Random();
        }
        /// <summary>
        /// Fight between teams. 
        /// </summary>
        /// <returns></returns>
        public string Match()
        {
            List<Player> blueTeamAlivePlayers = new List<Player>();
            List<Player> redTeamAlivePlayers = new List<Player>();
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan(0, 02, 0);
            TimeSpan time;

            do
            {
                sw.Start();
                time = ts - sw.Elapsed;
                Console.Clear();
                blueTeamAlivePlayers.Clear();
                redTeamAlivePlayers.Clear();
                Console.WriteLine(alivePlayersInTeams());
                foreach (Player item in blue.playersInTeam)
                {
                    if (item.alive)
                    {
                        blueTeamAlivePlayers.Add(item);
                    }
                }
                foreach (Player item in red.playersInTeam)
                {
                    if (item.alive)
                    {
                        redTeamAlivePlayers.Add(item);
                    }
                }
                Console.WriteLine("--------------------------------------------");
                if (time.Seconds < 10)
                    Console.WriteLine("Time game {0}:0{1}", time.Minutes, time.Seconds);
                else
                    Console.WriteLine("Time game {0}:{1}", time.Minutes, time.Seconds);

                Console.WriteLine("Alive in blue: {0} | Alive in red: {1}", blueTeamAlivePlayers.Count, redTeamAlivePlayers.Count);
                if (blueTeamAlivePlayers.Count > 0 && redTeamAlivePlayers.Count > 0)
                {
                    Console.WriteLine("\nAtack BLUE:");
                    Console.WriteLine("{0}", blueTeamAlivePlayers[playerAttack.Next(blueTeamAlivePlayers.Count)].Attack(redTeamAlivePlayers[playerAttack.Next(redTeamAlivePlayers.Count)]));

                    Console.WriteLine("\nAtack RED:");
                    Console.WriteLine("{0}", redTeamAlivePlayers[playerAttack.Next(redTeamAlivePlayers.Count)].Attack(blueTeamAlivePlayers[playerAttack.Next(blueTeamAlivePlayers.Count)]));
                }
                Thread.Sleep(2000);


            } while (blueTeamAlivePlayers.Count > 0 && redTeamAlivePlayers.Count > 0 && sw.Elapsed.Minutes < 2);

            return (blueTeamAlivePlayers.Count > redTeamAlivePlayers.Count) ? "WON BLUE" : (redTeamAlivePlayers.Count > blueTeamAlivePlayers.Count) ? "WON RED" : "DRAW";
        }
        /// <summary>
        /// Table alive players
        /// </summary>
        /// <returns></returns>
        public string alivePlayersInTeams()
        {
            string playersInTeamBlue = "\nBlue team:\n";
            string playersInTeamRed = "\nRed team:\n";
            foreach (Player item in blue.playersInTeam)
            {
                if (item.alive)
                    playersInTeamBlue += string.Format("{0} ({1}) - alive\n", item, item.champion);
                else
                    playersInTeamBlue += string.Format("{0} ({1}) - died\n", item, item.champion);
            }
            foreach (Player item in red.playersInTeam)
            {
                if (item.alive)
                    playersInTeamRed += string.Format("{0} ({1}) - alive\n", item, item.champion);
                else
                    playersInTeamRed += string.Format("{0} ({1}) - died\n", item, item.champion);
            }
            return playersInTeamBlue + playersInTeamRed;
        }
    }
}
