using SwinGameSDK;
using Template.Utilities;

namespace Template.Scenes
{
    public class MainMenuScene : Scene
    {
        public override void OnUpdate()
        {
            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.IsRunning = false;
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE)) Program.SceneManager.PushScene(new PlayScene());

            base.OnUpdate();
        }

        public override void OnRender()
        {
            base.OnRender();

            FontUtilities.DrawCenteredString(FontUtilities.Arial24, "Platformer", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f, Color.White);
            FontUtilities.DrawCenteredString(FontUtilities.Arial12, "Space - Play", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f + 20, Color.White);
            FontUtilities.DrawCenteredString(FontUtilities.Arial12, "Escape - Exit", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f + 35, Color.White);
        }

        public override void OnEnter()
        {
            SwinGame.SetCameraPos(new Point2D
            {
                X = 0,
                Y = 0
            });
        }
    }
}