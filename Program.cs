using SwinGameSDK;
using Template.Scenes;

namespace Template
{
    internal class Program
    {
        public static SceneManager SceneManager;
        public static bool IsRunning;

        private void Start(string[] args)
        {
            SwinGame.OpenGraphicsWindow("Platformer", 1280, 720);

            SceneManager = new SceneManager();
            SceneManager.PushScene(new MainMenuScene());

            Run();
        }

        private void Run()
        {
            IsRunning = true;

            while (!SwinGame.WindowCloseRequested() && IsRunning)
            {
                SwinGame.ProcessEvents();
                SceneManager.CurrentScene.OnUpdate();

                SwinGame.ClearScreen(Color.Black);
                SceneManager.CurrentScene.OnRender();
                SwinGame.RefreshScreen(60);
            }

            Stop();
        }

        private void Stop()
        {
            IsRunning = false;
        }

        private static void Main(string[] args) => new Program().Start(args);
    }
}