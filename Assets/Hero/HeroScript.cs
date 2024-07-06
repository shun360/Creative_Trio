using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class HeroScript : MonoBehaviour
{
    public static HeroClass hero = new HeroClass();
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    private bool shouldMove = false;
    private bool isReturning = false;
    Vector3 originPosition;

    private void HeroMove(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        Debug.Log($"HeroMoveが呼ばれた時のtargetPosition: {targetPosition}");
    }
    public void AttackMotion()
    {
        HeroMove(10, 10);
    }

    
    private void Awake()
    {
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
            
        }
        if(hero.NowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            //ゲームオーバー処理を書く
            GameOver();
        }
    }
   void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    
}
