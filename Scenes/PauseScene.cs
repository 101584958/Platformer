using SwinGameSDK;
using Template.Utilities;

namespace Template.Scenes
{
    public class PauseScene : Scene
    {
        public override void OnUpdate()
        {
            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.SceneManager.PopScene();
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE)) Program.SceneManager.SetScene(new MainMenuScene());

            base.OnUpdate();
        }

        public override void OnRender()
        {
            base.OnRender();

            FontUtilities.DrawCenteredString(FontUtilities.Arial24, "Paused", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f, Color.White);
            FontUtilities.DrawCenteredString(FontUtilities.Arial12, "Escape - Continue playing", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f + 20, Color.White);
            FontUtilities.DrawCenteredString(FontUtilities.Arial12, "Space - Return to home screen", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f + 35, Color.White);
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