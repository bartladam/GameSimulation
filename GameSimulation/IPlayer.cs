using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    internal interface IPlayer
    {
        string nickName { get; }
        int hitpoints { get; }
        int attackDamage { get; }
        int resistanceChampion { get; }
        string Attack(IPlayer player);
        string Defend(int attackDamage);
        bool alive { get; }
    }
}
