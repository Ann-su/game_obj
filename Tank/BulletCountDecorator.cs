using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_obj
{
    internal class BulletCountDecorator :TankDecorator
    {
        public override int BulletCount { get => base.BulletCount; set => base.BulletCount = value + 5; }
        public BulletCountDecorator(Tank tank) : base(tank) { }
    }
}
