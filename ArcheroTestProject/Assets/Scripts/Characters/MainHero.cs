using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHero : Character
{
    [SerializeField] Transform _shootingPoint;
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] FloatingJoystick joystick;
    CharacterController _controller;
    //ShootingEnemy _shootingEnemy;    

    //public List<Enemy> enemiesInLevel;// ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ LevelManager
    Transform target;
    bool isMoving; //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½

    void Start() 
    {
        _controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();
        AutoFindTarget();
        Attack();      
    }

    public override void Attack()// ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ObjectPool ï¿½ ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
    {
        if (!isMoving)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTime < reloadTimer)
            {
                //Debug.Log("Arrow");
                var arrow = Instantiate(_arrowPrefab, _shootingPoint.position, _shootingPoint.rotation);
                arrow.TryGetComponent<Rigidbody>(out Rigidbody rb);
                rb.AddForce(_shootingPoint.forward * 10, ForceMode.VelocityChange);
                reloadTimer = 0;
            }
        }       
    }

    public override void Die()
    {
        Destroy(gameObject);//ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
    }

    public override void Move()
    {        
        float moveV = joystick.Vertical;
        float moveH = joystick.Horizontal;        
        _controller.SimpleMove(new Vector3(moveH, -9.81f, moveV) * movementSpeed);
    
    }
    public void AutoFindTarget()// ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ 
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackDistance);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].CompareTag("Enemy"))
            {
                target = enemies[i].gameObject.transform;
            }            
        }
        //for (int i = 0; i < enemiesInLevel.Count; i++)
        //{
        //    if (enemiesInLevel[i] == null)
        //    {
        //        enemiesInLevel.RemoveAt(i);
        //    }
        //    if (Vector3.Distance(transform.position, enemiesInLevel[i].transform.position) < attackDistance)
        //    {                
        //        target = enemiesInLevel[i].transform;
                
        //    }
        //}

        if (target != null) 
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))//ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ ShootingEnemy??
        {
            TakeDamage(20);//ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ damage ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
            //Debug.Log("Got it");
            //TakeDamage(collision.gameObject.GetComponent<MovingEnemy>().damage);
        }
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
            
            //Debug.Log("Got it");

        }

    }
}

