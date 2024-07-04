using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector3 startPos = new Vector3(-100, 2, 5);
    
    public Rigidbody rb;
    public void set()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        set();
    }

    void Update()
    {
        
    }
}