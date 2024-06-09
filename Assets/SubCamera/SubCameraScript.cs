using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraScript : MonoBehaviour
{
    private GameObject bollObj;
    private Vector3 startPosi = new Vector3(0, 2, -8);
    // Start is called before the first frame update
    void Start()
    {
        this.bollObj = GameObject.Find("Boll");
        transform.position = bollObj.transform.position + startPosi;
        transform.LookAt(bollObj.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
