using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float shootSpeed;
    [SerializeField]
    GameObject shootingPoint;

    public override void Attack()
    {
        if (CheckDistanceToPlayer()) 
        {
            
            reloadTimer += Time.deltaTime;
            if (reloadTime < reloadTimer)
            {
                
                var sphere = Instantiate(prefab, shootingPoint.transform.position, Quaternion.identity);
                sphere.TryGetComponent<Rigidbody>(out Rigidbody rb);
                rb.AddForce(shootingPoint.transform.forward * 10, ForceMode.Impulse);
                reloadTimer = 0;
            }
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
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        Attack();
    }
}
