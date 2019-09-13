using SwinGameSDK;

namespace Template
{
    internal class Program
    {
        private void Start(string[] args)
        {
            SwinGame.OpenGraphicsWindow("Template", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            // Handle initialization here.

            Run();
        }

        private void Run()
        {
            while (!SwinGame.WindowCloseRequested())
            {
                SwinGame.ProcessEvents();

                // Handle input here.

                SwinGame.ClearScreen(Color.Black);

                // Handle rendering here.

                SwinGame.DrawFramerate(0.0f, 0.0f);
                SwinGame.RefreshScreen(60);
            }

            Stop();
        }

        private void Stop()
        {
            // Handle termination here.
        }

        private static void Main(string[] args) => new Program().Start(args);
    }
}