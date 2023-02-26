using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal class SelectTankScene :Scene
    {
        public SelectDecoratorScene selectDecoratorScene = new SelectDecoratorScene();
        public static int SceneID = 1;
        private static string chosenTank;
        public static Tank chosenTankObj;
        public static string ChosenTank
        {
            get { return chosenTank; }
            set { chosenTank = value; }
        }
        protected override int Position
        {
            get { return base.Position; }
            set { if (value >= 0 && value <= 1) base.Position = value; }
        }
        public override void Start()
        {
            GameManager.ActiveSceneId = SceneID;
            base.Start();
            sceneGraphic.DrawSelectTank();
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("Scene ID {0}", SceneID);
        }
        public override void KeyPressed(Key key)
        {
            if (key == Key.Space)
            {
                if (Position == 0)
                {
                    chosenTank = AsciiAssets.KV1;
                    chosenTankObj = new Tank();
                }
                if (Position == 1)
                {
                    chosenTankObj = new Tank(120, 400, false, 5);
                    chosenTank = AsciiAssets.KV2;
                }
                selectDecoratorScene.Start();
                return;
            }
            base.KeyPressed(key);
        }
    }
}
