using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsBase : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableElement()
    {
        Debug.Log("Disabled: " + gameObject.name);
        GetComponent<Canvas>().gameObject.SetActive(false);
    }

    public void EnableElement()
    {
        Debug.Log("Enabled:" + gameObject.name);
        GetComponent<Canvas>().gameObject.SetActive(true);
    }
}
