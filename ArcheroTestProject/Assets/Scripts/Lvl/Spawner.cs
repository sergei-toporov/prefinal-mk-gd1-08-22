using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _archer;
    [SerializeField] private GameObject _runner;
    [SerializeField] private List<Transform> _listPositions;
    private List<GameObject> _listEnemy=new List<GameObject>();

    private void Start()
    {
        if (_archer==null||_runner==null)
        {
            _archer=GameObject.FindWithTag("Archer");
            _runner = GameObject.FindWithTag("Runner");
        }
    }

    public void Initialise(int count)
    {
        if (count>0 && _listPositions!=null && _listPositions.Count>count )
        {
            for (int i = 0; i < count; i++)
            {
                if (i%2==1)
                {
                  var newArcher=  Instantiate(_archer, _listPositions[i].position, Quaternion.identity);
                  _listEnemy.Add(newArcher);
                }
                else
                {
                    var newRunner=Instantiate(_runner, _listPositions[i].position, Quaternion.identity);
                    _listEnemy.Add(newRunner);
                }
            }
        }
        else
        {
            print("error from spawer");
        }
    }

    public void Clear()
    {
        print("try delite enemy");
        if (_listEnemy==null)
        {
            return;
        }

        foreach (var enemy in _listEnemy)
        {
            Destroy(enemy);
        }
    }
}
