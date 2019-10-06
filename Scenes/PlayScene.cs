using SwinGameSDK;

namespace Template.Scenes
{
    public class PlayScene : Scene
    {
        private TileMap _map;

        public PlayScene()
        {
            _map = new TileMap(@"Resources\levels\level-1.tmx");
        }

        ~PlayScene()
        {
            _map.Free();
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.SceneManager.PushScene(new PauseScene());
            
            _map.Draw();
        }
    }
}