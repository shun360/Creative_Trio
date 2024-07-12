using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraScript : MonoBehaviour
{
    private GameObject ball;
    private GameObject dot;
    private Vector3 center = new(-100, 5.5f, 58);
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
            transform.position = new(center.x, center.y + 6, center.z - 1);
            transform.LookAt(dot.transform.position);
        }
        else if(ball.transform.position.z < 68)
        {
            transform.position = ball.transform.position + plusPosi;
            transform.LookAt(ball.transform.position);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, center, ref velocity, 0.1f);
            transform.LookAt(dot.transform.position);

        }
    }
}
