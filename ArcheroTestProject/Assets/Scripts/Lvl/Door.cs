using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public event Action OpenedDoorEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Next Lvl");
            OpenedDoorEvent?.Invoke();
        }
    }
}
