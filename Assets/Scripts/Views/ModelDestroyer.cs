using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelDestroyer : MonoBehaviour
{
    public List<Collider> Colliders;
    public List<Rigidbody> Rigidbodies;

    private void Awake()
    {
        Colliders = GetComponentsInChildren<Collider>().ToList();
        Rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
        ResetModel();
    }

    public void ResetModel()
    {
        foreach (var collider in Colliders)
        {
            collider.enabled = false;
        }

        foreach (var rigidbody in Rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void DestroyModel(Vector3 explosionPosition, float radius, float force, float upModifier, float torqueForce)
    {
        foreach (var collider in Colliders)
        {
            collider.enabled = true;
        }

        foreach (var rigidbody in Rigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, explosionPosition, radius, upModifier, ForceMode.Impulse);
            rigidbody.AddTorque(Random.onUnitSphere * torqueForce, ForceMode.Impulse);
        }

        gameObject.transform.parent = null;
    }
}