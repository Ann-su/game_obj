using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    abstract class TankDecorator :Tank
    {
        protected Tank tank;
        public TankDecorator(Tank tank) { this.tank = tank; }
        
        public override int Attack()
        {
            return tank.Attack();
        }
    }
}
