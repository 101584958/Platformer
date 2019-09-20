using SwinGameSDK;

namespace Template.Scenes
{
    public class SetupScene : Scene
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.SceneManager.PopScene();
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE)) Program.SceneManager.PushScene(new PlayScene());
        }
    }
}