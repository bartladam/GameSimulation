using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    internal class Bot:Player
    {
        public Bot(string nickName, Player.gameChampions gameChampion) : base(nickName + " - BOT", gameChampion)
        {

        }
    }
}
