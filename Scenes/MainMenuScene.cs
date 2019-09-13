using SwinGameSDK;

namespace Template.Scenes
{
    public class MainMenuScene : Scene
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.EscapeKey)) Program.IsRunning = false;
            if (SwinGame.KeyTyped(KeyCode.SpaceKey)) Program.SceneManager.PushScene(new SetupScene());
        }
    }
}