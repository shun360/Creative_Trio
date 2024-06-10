using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraScript : MonoBehaviour
{
    private GameObject ballObj;
    private Vector3 startPosi = new Vector3(0, 2, -8);
    // Start is called before the first frame update
    void Start()
    {
        this.ballObj = GameObject.Find("Ball");
        transform.position = ballObj.transform.position + startPosi;
        transform.LookAt(ballObj.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
