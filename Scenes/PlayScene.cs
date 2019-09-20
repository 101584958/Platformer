using SwinGameSDK;

namespace Template.Scenes
{
    public class PlayScene : Scene
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.SceneManager.PushScene(new PauseScene());
        }
    }
}