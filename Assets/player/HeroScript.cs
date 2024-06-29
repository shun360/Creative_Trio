using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum CommandType
{
    Attack,
    Defense,
    Fireboll
}
public class HeroScript : MonoBehaviour
{
    public HeroClass hero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    private bool shouldMove = false;
    private bool isReturning = false;
    Vector3 originPosition;

    public void HeroMove(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        Debug.Log($"HeroMoveが呼ばれた時のtargetPosition: {targetPosition}");
    }


    
    private void Awake()
    {
        hero = new HeroClass();
        originPosition = new Vector3(15, 15, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        transform.position = originPosition;
        HeroMove(10,10);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove)
        {
            if(isReturning)
            {
                if (Vector3.Distance(transform.position, originPosition) < 0.1f)
                {
                    shouldMove = false;
                    velocity = Vector3.zero;
                    isReturning = false;
                    Debug.Log("originPositionに戻った");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, originPosition, ref velocity, 0.1f);
                }
            }
            else
            { 
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                { 
                    isReturning = true;
                    targetPosition = originPosition;
                    Debug.Log("Uターンする");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
                }
            }
            /*Debug.Log($"{transform.position} から {targetPosition}へ移動");
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
            if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                if (isReturning)
                {
                    if (Vector3.Distance(transform.position, originPosition) < 0.1f)
                    {
                        shouldMove = false;
                        velocity = Vector3.zero;
                        isReturning = false;
                        Debug.Log("originPositionに戻った");
                    }
                }
                else
                {
                    isReturning = true;
                    targetPosition = originPosition;
                    Debug.Log("Uターンする");
                }
            }*/
        }
        if(hero.HeroNowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            //ゲームオーバー処理を書く
        }
    }
}
