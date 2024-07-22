using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClass : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 right;
    private Vector3 left;
    private bool movingRight;
    private WallScript wall;
    private void Awake()
    {
        wall = FindObjectOfType<WallScript>();
        movingRight = true;
        velocity = Vector3.zero;
        right = new(-94, 1, transform.position.z);
        left = new(-106, 1, transform.position.z);
    }
    void Update()
    {
        if(wall != null)
        {
            if (wall.active)
            {

                if (movingRight)
                {
                    transform.Translate(0.03f, 0, 0);
                    if (Vector3.Distance(transform.position, right) < 1f)
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    transform.Translate(-0.03f, 0, 0);
                    if (Vector3.Distance(transform.position, left) < 1f)
                    {
                        movingRight = true;
                    }
                }
            }
        }
        
    }
}
