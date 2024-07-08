using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private Vector3 acce = new Vector3(0, 0, 30000);
    [SerializeField] private Vector3 left = new Vector3(-50, 0, 0);
    [SerializeField] private Vector3 right = new Vector3(50, 0, 0);
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
                transform.Translate(-0.1f, 0, 0);
            }
            else
            {
                Debug.Log("Ç±ÇÍà»è„ÇÕóéÇøÇ‹Ç∑");
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
                transform.Translate(0.1f, 0, 0);
            }
            else
            {
                Debug.Log("Ç±ÇÍà»è„ÇÕóéÇøÇ‹Ç∑");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
