using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace game_obj
{
    internal class MenuScene :Scene
    {

        public SelectTankScene selectTankScene = new SelectTankScene();
        public static int SceneID = 0;

        protected override int Position 
        {
            get { return base.Position; }
            set { if (value >= 0 && value <= 1) base.Position = value; }
        }
        public override void Start()
        {
            GameManager.ActiveSceneId = SceneID;
            base.Start();
            sceneGraphic.DrawMenu();
            Console.WriteLine("Scene ID {0}", SceneID);
        }
        public override void KeyPressed(Key key)
        {
            if (key == Key.Space)
            {
                if (Position == 0) { selectTankScene.Start(); return; }
                GameManager.isRunning = false;
            }

            base.KeyPressed(key);
        }
    }
}
