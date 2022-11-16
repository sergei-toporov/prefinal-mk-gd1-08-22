using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField] protected Transform target;//Игрок
    
    protected bool CheckDistanceToPlayer() 
    {
        if (Vector3.Distance(transform.position, target.position) < attackDistance) 
        {
            return true;
        }
        else
            return false;        
    }
   

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Finish"))
        {
            TakeDamage(10);
            Debug.Log("Got it");
        }
    }
}
