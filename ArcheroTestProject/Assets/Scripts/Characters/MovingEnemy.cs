using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    public override void Attack()
    {
        if (CheckDistanceToPlayer()) 
        {            
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    //public override void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("PlayerArrow"))
    //    {
    //        TakeDamage(10);
    //        Debug.Log("Got it");
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
