using SwinGameSDK;
using Template.Entities;

namespace Template.Scenes
{
    public abstract class Scene
    {
        public EntityManager EntityManager;

        public Scene()
        {
            EntityManager = new EntityManager();
        }

        public virtual void OnUpdate()
        {
            EntityManager.OnUpdate();
        }

        public virtual void OnRender()
        {
            EntityManager.OnRender();
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnLeave()
        {

        }
    }
}