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
}
