using Leopotam.Ecs;

namespace ECS.Utils.Extensions
{
    public static class GameExtensions
    {
        public static ref T GetAndFire<T>(this ref EcsEntity entity) where T : struct
        {
            entity.Get<T>();
            entity.Get<EventAddComponent<T>>();
            return ref entity.Get<T>();
        }

        public static void DelAndFire<T>(this ref EcsEntity entity) where T : struct
        {
            entity.Del<T>();
            entity.Get<EventRemoveComponent<T>>();
        }
    }
}