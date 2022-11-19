using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class LvlManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listMaps;
    [SerializeField] private GameObject _startMap;
    [SerializeField] private GameObject _character;
    private GameObject _currentMap;
    private Vector3 _baseMapPosition;
    private Vector3 _startCharacterPosition=new Vector3(0f,1.1f,-11f);
    private CharacterController _characterController;
    private Door _door;
    private Spawner _spawner;
    [SerializeField] private int countEnemy = 3;

    private void Awake()
    {
        _baseMapPosition = _startMap.transform.position;
        _currentMap = Instantiate(_startMap, _baseMapPosition, Quaternion.identity);
        _character = Instantiate(_character, _startCharacterPosition,Quaternion.identity);
        _characterController = _character.GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (countEnemy>7)
        {
            countEnemy = 7;
        }
        _door = _currentMap.GetComponentInChildren<Door>();
        _door.OpenedDoorEvent += SwitchLvlMap;
    }

    private void SwitchLvlMap()
    {
        _door.OpenedDoorEvent -= SwitchLvlMap;
        _currentMap.GetComponent<Spawner>().Clear();
        Destroy(_currentMap);
        ChangeMap();
    }

    private void ChangeMap()
    {
        SwitchCharacterController();
        _character.transform.position = _startCharacterPosition;
        SwitchCharacterController();
        _currentMap = Instantiate(GetRandomMap(),_baseMapPosition,Quaternion.identity);
        _currentMap.GetComponent<Spawner>().Initialise(countEnemy);
        print(_character.transform.position);
        _door = _currentMap.GetComponentInChildren<Door>();
        _door.OpenedDoorEvent += SwitchLvlMap;
        countEnemy += 1;
        print("End Change");
    }

    private GameObject GetRandomMap()
    {
        if (_listMaps.Count==0)
        {
            print("Exit");
            Application.LoadLevel(Application.loadedLevel);
        }
        var rdn = new Random();
        var randomIndex = rdn.Next(_listMaps.Count);
        var newMap = _listMaps[randomIndex];
        
        _listMaps.Remove(newMap);
        return newMap;
    }

    private void SwitchCharacterController()
    {
        _characterController.enabled = !_characterController.enabled;
    }

}
