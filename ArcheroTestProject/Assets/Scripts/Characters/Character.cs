using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] public int damage;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected float attackDistance;
    protected float reloadTimer;
    protected Vector3 startPosition;
    protected Quaternion startRotation;
    protected bool initialized = false;

    protected void Awake()
    {
        if (!initialized)
        {
            startPosition = transform.position;
            startRotation = transform.rotation;
            initialized = true;
        }        
    }

    public abstract void Move();
    public abstract void Attack();
    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public abstract void Die();

    public abstract void OnCollisionEnter(Collision collision);

    public void ResetPosition()
    {
        if (gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        CharacterController cc = gameObject.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
        }

        transform.position = startPosition;
        transform.rotation = startRotation;
        
        if (cc != null)
        {
            cc.enabled = true;
        }
    }
}
