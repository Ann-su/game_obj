using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class ATKDecorator :TankDecorator
    {
        public override int ATK { get => base.ATK; set => base.ATK = value + 200; }
        public ATKDecorator(Tank tank) : base(tank) { }
    }
}
