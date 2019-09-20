using SwinGameSDK;

namespace Template.Scenes
{
    public class MainMenuScene : Scene
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.IsRunning = false;
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE)) Program.SceneManager.PushScene(new SetupScene());
        }
    }
}