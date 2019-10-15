using SwinGameSDK;
using Template.Utilities;

namespace Template.Scenes
{
    public class WinScene : Scene
    {
        public override void OnUpdate()
        {
            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.SceneManager.SetScene(new MainMenuScene());

            FontUtilities.DrawCenteredString(FontUtilities.Arial24, "Congratulations! You win!", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f - 10, Color.White);
            FontUtilities.DrawCenteredString(FontUtilities.Arial12, "Press \"Escape\" to return to the Main Menu", SwinGame.ScreenWidth() / 2.0f, SwinGame.ScreenHeight() / 2.0f + 10, Color.White);

            base.OnUpdate();
        }
    }
}