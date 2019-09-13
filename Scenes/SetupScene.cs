using SwinGameSDK;

namespace Template.Scenes
{
    public class SetupScene : Scene
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.EscapeKey)) Program.SceneManager.PopScene();
            if (SwinGame.KeyTyped(KeyCode.SpaceKey)) Program.SceneManager.PushScene(new PlayScene());
        }
    }
}