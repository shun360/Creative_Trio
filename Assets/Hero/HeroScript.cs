using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using UnityEditor.Search;


public class HeroScript : HeroClass
{
       
    public IEnumerator Attack()
    {
        Debug.Log("Heroの攻撃");
        AttackMotion();
        MonsterClass t = MonsterScript.monList[targetNumber].GetComponent<MonsterClass>();
        t.TakeAttacked(NowATK);
        yield return new WaitForSeconds(0.1f);
        t.KnockBack();
    }
    

    
    void Start()
    {
        Debug.Log("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
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
                    Debug.Log("Uターン");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(targetNumber < MonsterScript.monList.Count - 1)
            {
                targetNumber++;
            }
            else
            {
                targetNumber = 0;
            }
            
        }
        if (NowHP <= 0)
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
