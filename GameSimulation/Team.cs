using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    /// <summary>
    /// Team is important for match between teams
    /// </summary>
    internal class Team
    {
        /// <summary>
        /// Players in current team
        /// </summary>
        public IPlayer[] playersInTeam { get; set; }
        public Team(IPlayer[] players)
        {
            this.playersInTeam = players;
        }
    }
}
