using System.Collections.Generic;

namespace Template.Scenes
{
    public class SceneManager
    {
        private Stack<Scene> _scenes;

        public Scene CurrentScene => _scenes.Peek();

        public SceneManager()
        {
            _scenes = new Stack<Scene>();
        }

        public void PushScene(Scene scene)
        {
            _scenes.Push(scene);
            scene.OnEnter();
        }

        public Scene PopScene()
        {
            Scene scene = _scenes.Peek();
            scene.OnLeave();

            return _scenes.Pop();
        }

        public void SetScene(Scene scene)
        {
            _scenes.Clear();
            PushScene(scene);
        }
    }
}