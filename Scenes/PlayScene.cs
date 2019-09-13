using SwinGameSDK;

namespace Template.Scenes
{
    public class PlayScene : Scene
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.EscapeKey)) Program.SceneManager.PushScene(new PauseScene());
        }
    }
}