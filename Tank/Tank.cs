using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class Tank
    {
        public int playerLvl = 0;
        public virtual int ATK { get; set; }
        public virtual int HP { get; set; }
        public virtual bool ReloadRate { get; set; }
        public virtual int BulletCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Tank()
        {
            ATK = 100;
            HP = 300;
            ReloadRate = false;
            BulletCount = 10;
            X = 0;
            Y = 0;
        }
        public Tank(int atk, int hp, bool reloadRate, int bulletCount)
        {
            ATK = atk;
            HP = hp;
            ReloadRate = reloadRate;
            BulletCount = bulletCount;
        }

        public virtual int Attack()
        {
            return ATK;
        }
    }
}
