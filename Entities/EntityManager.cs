using System.Collections.Generic;

namespace Template.Entities
{
    public class EntityManager
    {
        private List<Entity> _entities;
        private List<Entity> _removeQueue;

        private bool _sorted = true;

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

            if (!_sorted)
            {
                _entities.Sort((left, right) => left.ZIndex < right.ZIndex ? -1 : 1);
                _sorted = true;
            }
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            _sorted = false;
        }

        public void RemoveEntity(Entity entity)
        {
            _removeQueue.Add(entity);
        }

        public List<T> GetEntitiesByType<T>() where T : Entity
        {
            return _entities.FindAll(x => x is T).ConvertAll(x => (T)x);
        }
    }
}