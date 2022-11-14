using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EventManager.Manager.OnRKey.TriggerEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.Manager.OnSpaceKey.TriggerEvent();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventManager.Manager.OnPauseToggle.TriggerEvent();
        }
    }
}
