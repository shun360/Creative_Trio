using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraScript : MonoBehaviour
{
    private GameObject ball;
    private Vector3 plusPosi = new Vector3(0, 4, -12);
    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("Ball");
        transform.position = ball.transform.position + plusPosi;
        transform.LookAt(ball.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = ball.transform.position + plusPosi;
    }
}
