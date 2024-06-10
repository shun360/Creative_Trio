using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum BattleCmd
{
    attack,
    defence,
    fireboll
}
public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 currentPosi;
    [SerializeField] private Transform moveTarget;
    [SerializeField] private float smoothTime = 10f;
    private Vector2 currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        transform.position = new Vector2(0, 0);
        currentPosi = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.SmoothDamp(
            currentPosi,
            new Vector2(200, 200),
            ref currentSpeed,
            smoothTime
        
        );
    }


    // Update is called once per frame
    void Update()
    {


    }
}
