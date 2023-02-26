using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal class SelectDecoratorScene :Scene
    {
        public BattleScene battleScene = new BattleScene();

        public static int SceneID = 2;

        protected override int Position
        {
            get { return base.Position; }
            set { if (value >= 0 && value <= 3) base.Position = value; }
        }
        public override void Start()
        {
            GameManager.ActiveSceneId = SceneID;
            base.Start();
            sceneGraphic.DrawDecorators();
        }
        public static List<Tank> tankList = new List<Tank>();

        public override void KeyPressed(Key key)
        {
            Tank playersTank = SelectTankScene.chosenTankObj;

            if (key == Key.Space)
            {
                if (Position == 0)
                {
                    playersTank = new HPDecorator(playersTank);
                }
                if (Position == 1)
                {
                    playersTank = new BulletCountDecorator(playersTank);
                }
                if (Position == 2)
                {
                    playersTank = new ATKDecorator(playersTank);
                }
                if (Position == 3)
                {
                    playersTank = new ReloadRateDecorator(playersTank);
                }

                tankList.Add(playersTank);
                if (tankList.Count == 3)
                {
                    battleScene.Start();
                    return;
                }
            }
            if (key == Key.W) Position -= 1;
            if (key == Key.S) Position += 1;
            sceneGraphic.DrawCursor(Position);
        }
    }
}
