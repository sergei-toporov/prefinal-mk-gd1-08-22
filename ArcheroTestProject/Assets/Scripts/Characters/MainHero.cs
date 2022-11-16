using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHero : Character
{
    [SerializeField] Transform _shootingPoint;
    [SerializeField] GameObject _arrowPrefab;
    CharacterController _controller;
    

    public List<Enemy> enemiesInLevel;// �������� ����� ���� ������ ��������� �� LevelManager
    Transform target;
    bool isMoving; //�������� ����� ��� � �� ������� ��� ��������
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
        


    public override void Attack()// ������� ObjectPool � ��� �� ������� ���� �������
    {
        if (!isMoving)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTime < reloadTimer)
            {
                Debug.Log("Arrow");
                var arrow = Instantiate(_arrowPrefab, _shootingPoint.position, _shootingPoint.rotation);
                arrow.TryGetComponent<Rigidbody>(out Rigidbody rb);
                rb.AddForce(_shootingPoint.forward * 10, ForceMode.VelocityChange);
                reloadTimer = 0;
            }
        }

    }

    public override void Die()
    {
        Destroy(gameObject);//��������
    }

    public override void Move()
    {
        
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");        
        _controller.SimpleMove(new Vector3(moveH, -9.81f, moveV) * movementSpeed);
       

    }
    public void AutoFindTarget()// ����� �������� ���� ������� ���������� 
    {
        for (int i = 0; i < enemiesInLevel.Count; i++)
        {
            if (enemiesInLevel[i] == null)
            {
                enemiesInLevel.RemoveAt(i);
            }
            if (Vector3.Distance(transform.position, enemiesInLevel[i].transform.position) < attackDistance)
            {                
                target = enemiesInLevel[i].transform;
                
            }
        }

        if (target != null) 
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }    
}
