using SwinGameSDK;

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
    }
}