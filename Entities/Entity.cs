﻿namespace Template.Entities
{
    public abstract class Entity
    {
        public abstract int ZIndex { get; }

        public abstract void OnUpdate(EntityManager entityManager);
    }
}