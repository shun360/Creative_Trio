using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector3 startPos = new Vector3(-100, 2, 5);
    
    public Rigidbody rb;
    public void Set()
    {
        rb.isKinematic = true;
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Set();
    }

    void Update()
    {
        
    }
}