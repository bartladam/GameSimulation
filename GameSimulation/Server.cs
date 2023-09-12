using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    /// <summary>
    /// Players play across server
    /// </summary>
    internal class Server
    {
        /// <summary>
        /// For differentiate server
        /// </summary>
        public string nameServer { get; private set; }
        /// <summary>
        /// Server has maximum capacity of players / bots
        /// </summary>
        public const int MaxPlayersOnServer = 10;
        /// <summary>
        /// Array players on server who play game
        /// </summary>
        private IPlayer[] players { get; set; }
        /// <summary>
        /// Size team who will be play the game against enemy team
        /// </summary>
        private int sizeTeam { get; set; } = 5;
        /// <summary>
        /// used for from what value take players from server to team. 
        /// (First wave 0-4 players, second 5-9)
        /// </summary>
        public int progress { get; private set; } = 0;
        public Server(string nameServer)
        {
            this.nameServer = nameServer;
            players = new IPlayer[MaxPlayersOnServer];
        }
        /// <summary>
        /// Possible join each player to server, to max capacity 10
        /// </summary>
        /// <param name="player"></param>
        public void JoinToServer(IPlayer player)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] is null)
                {
                    players[i] = player;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        /// <summary>
        /// Makes team for game. This method must be realize 2x times. (Enemy team x Your team)
        /// </summary>
        /// <returns></returns>
        private Team MakeTeams()
        {
            IPlayer[] teamMates = new IPlayer[5];
            for (int i = 0; i < sizeTeam; i++)
            {
                teamMates[i] = players[progress + i];
            }
            progress += 5;

            if (progress > MaxPlayersOnServer)
            {
                progress = 0;
            }
            return new Team(teamMates);
        }
        /// <summary>
        /// This method start new Arena for match and set 2 teams (Enemy x Your)
        /// </summary>
        /// <returns></returns>
        public string ArenaMatch()
        {
            Arena arena = new Arena(MakeTeams(), MakeTeams());
            return arena.Match();

        }
        /// <summary>
        /// Order and write all players on server
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string playersOnServer = "";
            var orderPlayers = from i in players
                               orderby i.nickName
                               select i;

            foreach (IPlayer item in orderPlayers)
            {
                playersOnServer += item + "\n";
            }
            return string.Format("Players on server: \n\n{0} ", playersOnServer);
        }
    }
}
