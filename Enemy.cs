using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_The_Stars
{
    public class Enemy
    {
        public int Damage = 40;
        public int Health = 500;
        public int CountHits = 0;
        //public int Hit(Player player)
        //{
        //    CountHits++;
        //    return player.Health -= Damage;
        //}

        public int Ultimate()
        {
            if (CountHits == 3) return 70;
            return 0;
        }
    }
}
