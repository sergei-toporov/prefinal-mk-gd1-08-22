using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    public GameEvent GameEvent;
    public UnityEvent EventResponse;

    private void OnEnable()
    {
        GameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        GameEvent.RemoveListener(this);
    }

    public void OnEventTrigger()
    {
        EventResponse.Invoke();
    }
}
