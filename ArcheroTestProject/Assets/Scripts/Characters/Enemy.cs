using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField] protected Transform target;//Игрок
    MainHero _mainHero;
    
    protected bool CheckDistanceToPlayer() 
    {
        if (Vector3.Distance(transform.position, target.position) < attackDistance) 
        {
            return true;
        }
        else
            return false;        
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerArrow"))//Как дестроить стрелу если не попала никуда??
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
            //Debug.Log("Got it");
        }
    }




}
