using System;

namespace Managers.Scripts
{
    public class SceneFactory
    {
        public enum Scene
        {
            OpeningScene,
            GameScene,
            GameOverScene
        }
        
        public static String LoadScene(Scene scene)
        {
            switch (scene)
            {
                case Scene.OpeningScene:
                    return "OpeningScene";
                case Scene.GameScene:
                    return "GameScene";
                case Scene.GameOverScene:
                    return "GameOverScene";
                default:
                    return string.Empty;
            }
        }
    }
}