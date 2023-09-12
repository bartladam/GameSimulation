using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    /// <summary>
    /// Where is not player there is bot
    /// </summary>
    internal class Bot:Player
    {
        public Bot(string nickName, Player.gameChampions gameChampion) : base(nickName + " - BOT", gameChampion)
        {

        }
    }
}
