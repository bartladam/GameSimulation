using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    /// <summary>
    /// Individual players in team with own champion
    /// </summary>
    internal class Player:IPlayer
    {
        /// <summary>
        /// Bot or Player must have name for recognize them
        /// </summary>
        public string nickName { get; private set; }
        /// <summary>
        /// Champion must have hitpoints which lose in fight
        /// </summary>
        public int hitpoints { get; private set; }
        /// <summary>
        /// For save maximum health champion = It counts losed hitpoints from max hitpoints
        /// </summary>
        public int maxHitpoints { get; private set; }
        /// <summary>
        /// Used for fight when champion make damage to enemy bot
        /// </summary>
        public int attackDamage { get; private set; }
        public int resistanceChampion { get; private set; }
        /// <summary>
        /// Used for choose champion
        /// </summary>
        public enum gameChampions { Mage, Warrior, Dwarf };
        public gameChampions champion { get; private set; }
        /// <summary>
        /// On chosen champion we must set his personal stats (damage, hitpoints, resistance) 
        /// </summary>
        private SetChampionStats<gameChampions> setStats { get; set; }
        /// <summary>
        /// Is champion alive or not. Yes = fight continue, No = fight for this champ end
        /// </summary>
        public bool alive { get; set; } = true;
        public Player(string nickName, gameChampions gameChampion)
        {
            this.nickName = nickName;
            this.champion = gameChampion;
            setStats = new SetChampionStats<gameChampions>(gameChampion);
            this.maxHitpoints = setStats.hitpoints;
            this.hitpoints = setStats.hitpoints;
            this.attackDamage = setStats.attackDamage;
            this.resistanceChampion = setStats.resistanceChampion;
        }
        /// <summary>
        /// Champion attack on enemy bot if they are both alive
        /// Died champion can't attack
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public string Attack(IPlayer player)
        {
            if (player.alive && alive)
            {
                return string.Format("{0} have attacked on enemy with dmg {1}\n{2}", nickName, attackDamage, player.Defend(attackDamage));
            }
            else
            {
                Console.WriteLine("died");
            }
            return "";
        }

        /// <summary>
        /// If player attack is successfully, enemy have to defend it
        /// </summary>
        /// <param name="attackDamage"></param>
        /// <returns></returns>
        public string Defend(int attackDamage)
        {
            hitpoints -= (attackDamage + -resistanceChampion);
            if ((hitpoints <= 0))
            {
                alive = false;
                hitpoints = 0;
            }

            return string.Format("{0} have got damage {1} hitpoints ({2}/{3})", nickName, attackDamage - resistanceChampion, hitpoints, maxHitpoints);

        }
        public override string ToString()
        {
            return nickName;
        }
    }
}
