using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private Vector3 acce = new Vector3(0, 0, 1000);
    [SerializeField] private Vector3 left = new Vector3(-20, 0, 0);
    [SerializeField] private Vector3 right = new Vector3(20, 0, 0);
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Ahead()
    {
        rb.AddForce(acce);
    }
    public void CurveLeft()
    {
        rb.AddForce(left);
    }
    public void CurveRight()
    {
        rb.AddForce(right);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Ahead();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CurveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CurveRight();
        }
    }
}
