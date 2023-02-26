using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class ReloadRateDecorator :TankDecorator
    {
        public override bool ReloadRate { get => base.ReloadRate; set => base.ReloadRate = true; }
        
        public ReloadRateDecorator(Tank tank) : base(tank) { }
    }
}
