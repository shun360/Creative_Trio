using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraScript : MonoBehaviour
{
    private GameObject ball;
    private GameObject dot;
    private Vector3 center = new(-100, 11.5f, 57);
    private Vector3 plusPosi = new(0, 4, -12);
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        ball = GameObject.Find("Ball");
        dot = GameObject.Find("Center Dot");
        transform.position = ball.transform.position + plusPosi;
        transform.LookAt(ball.transform.position);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = center;
            transform.LookAt(dot.transform.position);
        }
        else if(ball.transform.position.z < 68)
        {
            transform.position = ball.transform.position + plusPosi;
            transform.LookAt(ball.transform.position);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, center, ref velocity, 0.5f);
            transform.LookAt(dot.transform.position);

        }
    }
}
