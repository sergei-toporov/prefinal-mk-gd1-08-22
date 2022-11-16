using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }   
    void Update()
    {
        //rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
    }

}
