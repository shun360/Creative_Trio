using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraScript : MonoBehaviour
{
    private GameObject ball;
    private Vector3 center = new(-100, 5.5f, 58);
    private Vector3 plusPosi = new(0, 4, -12);
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        transform.position = ball.transform.position + plusPosi;
        transform.LookAt(ball.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.z < 68)
        {
            transform.position = ball.transform.position + plusPosi;
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, center, ref velocity, 0.1f);
            
        }
    }
}
