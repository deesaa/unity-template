using Leopotam.Ecs;
using UnityEngine;

public abstract class LinkableView : MonoBehaviour, ILinkable
{
    protected EcsEntity Entity;
    public int Hash => transform.GetHashCode();
    public Transform Transform => transform;
    public int UnityInstanceId => gameObject.GetInstanceID();

    public virtual void Link(EcsEntity entity)
    {
        Entity = entity;
    }

    public virtual void Destroy()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
            Destroy(gameObject);
        else
            DestroyImmediate(gameObject);
#else
        Destroy(gameObject);
#endif
    }


    public bool TryGetEntity(out EcsEntity entity)
    {
        if (Entity.IsAlive())
        {
            entity = Entity;
            return true;
        }
        entity = EcsEntity.Null;
        return false;
    }

    public ref T Get<T>() where T : struct
    {
        return ref Entity.Get<T>();
    }
}