using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class HPDecorator :TankDecorator
    {
        public override int HP { get => base.HP; set => base.HP = value + 100; }
        public HPDecorator(Tank tank) : base(tank) { }
    }
}
