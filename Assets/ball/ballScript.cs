using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public Vector3 acce = new(0, 0, 30000);
    [SerializeField] public Vector3 left = new(-50, 0, 0);
    [SerializeField] public Vector3 right = new(50, 0, 0);
    private bool wentLeft = false;
    private bool wentRight = false;
    private Rigidbody rb;
    private Vector3 startPos = new Vector3(-100, 2, 5);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Set();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Ahead();
        }
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CurveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CurveRight();
        }
    }

    public void Set()
    {
        
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
    
    
    public void Ahead()
    {
        if (GameManager.Instance.isPlaying && !GameManager.Instance.throwStart)
        {
            GameManager.Instance.throwStart = true;
            rb.AddForce(acce);
        }
    }
    public void CurveLeft()
    {
        if (GameManager.Instance.throwStart)
        {
            rb.AddForce(left);
        }
        else
        {
            if (transform.position.x > -106)
            {
                wentRight = false;
                transform.Translate(-0.1f, 0, 0);
            }
            else
            {
                if (!wentLeft)
                {
                    wentLeft = true;
                    Debug.Log("Ç±ÇÍà»è„ÇÕóéÇøÇ‹Ç∑");
                }
            }
        }

    }
    public void CurveRight()
    {
        if (GameManager.Instance.throwStart)
        {
            rb.AddForce(right);
        }
        else
        {
            if (transform.position.x < -94)
            {
                wentLeft = false;
                transform.Translate(0.1f, 0, 0);
            }
            else
            {
                if (!wentRight)
                {
                    wentRight = true;
                    Debug.Log("Ç±ÇÍà»è„ÇÕóéÇøÇ‹Ç∑");
                }
            }
        }
    }
    protected void Acceleration(float multiple)
    {
        acce = new Vector3(0, 0, acce.z * multiple);
    }
    protected void ChangeScale(float multiple)
    {
        transform.localScale = new Vector3(transform.lossyScale.x * multiple, transform.lossyScale.y * multiple, transform.lossyScale.z * multiple);
    }
    //ïÒèV
    public void DoubleControl()
    {
        left = new Vector3(left.x * 2, 0, 0);
        right = new Vector3(right.x * 2, 0, 0);
    }
    public void DoubleAcceleration()
    {
        Acceleration(2);
    }
    public void Grow()
    {
        ChangeScale(1.2f);
        rb.mass *= 1.5f;
        Acceleration(1.3f);
    }
    
}