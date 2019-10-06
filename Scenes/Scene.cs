using SwinGameSDK;

namespace Template.Scenes
{
    public abstract class Scene
    {
        public virtual void OnUpdate()
        {
            SwinGame.DrawText($"Scene: {GetType().Name.Remove(GetType().Name.Length - 5)}", Color.White, 2.0f, 14.0f);
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnLeave()
        {
            
        }
    }
}