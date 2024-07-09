using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTest : MonoBehaviour
{
    [SerializeField] private Vector3 acce = new(0, 0, 30000);
    [SerializeField] private Vector3 left = new(-50, 0, 0);
    [SerializeField] private Vector3 right = new(50, 0, 0);
    private bool wentLeft = false;
    private bool wentRight = false;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        if(GameManager.Instance.throwStart)
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
                if(!wentRight)
                {
                    wentRight = true;
                    Debug.Log("Ç±ÇÍà»è„ÇÕóéÇøÇ‹Ç∑");
                }
            }
        }
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
}
