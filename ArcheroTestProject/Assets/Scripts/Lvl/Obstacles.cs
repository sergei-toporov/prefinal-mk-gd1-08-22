using UnityEngine;

public abstract class Obstacles : MonoBehaviour
{
    public abstract float Demage { get; }
    public abstract void OnTriggerEnter(Collider other);
}
