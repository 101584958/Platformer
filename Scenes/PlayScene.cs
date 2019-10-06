using SwinGameSDK;
using Template.Entities;

namespace Template.Scenes
{
    public class PlayScene : Scene
    {
        private TileMap _map;
        private Player _player;
        public PlayScene()
        {
            _map = new TileMap(@"Resources\levels\level-1.tmx");
            _player = new Player(SwinGame.LoadBitmap(@"Resources\player.png"));
            EntityManager.AddEntity(_map);
            EntityManager.AddEntity(_player);
        }
        

        ~PlayScene()
        {
            _map.Free();
        }

        public override void OnUpdate()
        {
            if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) Program.SceneManager.PushScene(new PauseScene());
            base.OnUpdate();
        }
    }
}