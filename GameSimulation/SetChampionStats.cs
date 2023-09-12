using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    internal class SetChampionStats<T>
    {
        /// <summary>
        ///  set hitpoints for chosen champion
        /// </summary>
        public int hitpoints { get; private set; }
        /// <summary>
        /// set attackDamage for chosen champion
        /// </summary>
        public int attackDamage { get; private set; }
        /// <summary>
        /// set resistance for chosen champion
        /// </summary>
        public int resistanceChampion { get; private set; }
        public SetChampionStats(T gameChampion)
        {
            if (gameChampion.ToString().Equals("Mage"))
            {
                hitpoints = 180;
                attackDamage = 70;
                resistanceChampion = 30;
            }
            if (gameChampion.ToString().Equals("Warrior"))
            {
                hitpoints = 200;
                attackDamage = 50;
                resistanceChampion = 40;
            }
            if (gameChampion.ToString().Equals("Dwarf"))
            {
                hitpoints = 150;
                attackDamage = 90;
                resistanceChampion = 20;
            }
        }
    }
}
