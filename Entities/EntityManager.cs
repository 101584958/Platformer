using System.Collections.Generic;

namespace Template.Entities
{
    public class EntityManager
    {
        private List<Entity> _entities;
        private List<Entity> _removeQueue;

        public EntityManager()
        {
            _entities = new List<Entity>();
            _removeQueue = new List<Entity>();
        }

        public void OnUpdate()
        {
            foreach (Entity entity in _entities) entity.OnUpdate(this);
            foreach (Entity entity in _removeQueue) _entities.Remove(entity);
            _removeQueue.Clear();
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _removeQueue.Add(entity);
        }

        public List<T> GetEntitiesByType<T>() where T : Entity
        {
            return _entities.FindAll(x => x is T).ConvertAll(x => (T) x);
        }
    }
}