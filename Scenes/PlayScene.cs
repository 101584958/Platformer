using SwinGameSDK;
using Template.Entities;

namespace Template.Scenes
{
    public class PlayScene : Scene
    {
        private TileMap _map;

        public PlayScene()
        {
            _map = new TileMap(@"Resources\levels\level-1.tmx", EntityManager);
            EntityManager.AddEntity(_map);
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