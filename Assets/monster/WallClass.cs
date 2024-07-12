using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClass : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 right;
    private Vector3 left;
    private bool movingRight = true;
    private bool firstRight = false;
    private WallScript wall;
    private void Awake()
    {
        wall = FindObjectOfType<WallScript>();
        right = new(-94, 1, transform.position.z);
        left = new(-106, 1, transform.position.z);
    }
    void Update()
    {
        if(wall.active)
        {
            if (!firstRight)
            {
                transform.Translate(0.02f, 0, 0);
                if (Vector3.Distance(transform.position, right) < 0.1f)
                {
                    movingRight = false;
                    firstRight = true;
                }
            }
            else if(movingRight)
            {
                transform.position = Vector3.SmoothDamp(transform.position, right, ref velocity, 2f);
                if(Vector3.Distance(transform.position, right) < 1f)
                {
                    movingRight = false;
                }
            }
            else 
            {
                transform.position = Vector3.SmoothDamp(transform.position, left, ref velocity, 2f);
                if (Vector3.Distance(transform.position, left) < 1f)
                {
                    movingRight= true;
                }
            }
        }
    }
}
