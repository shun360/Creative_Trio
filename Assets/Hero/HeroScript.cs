using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using UnityEditor.Search;


public class HeroScript : HeroClass
{
    private Vector3 velocity = Vector3.zero;
    private int targetNumber = 0;
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
    public IEnumerator Attack()
    {
        AttackMotion();
        MonsterClass t = MonsterScript.monInstances[targetNumber].GetComponent<MonsterClass>();
        t.TakeAttacked(NowATK);
        yield return new WaitForSeconds(0.1f);
        t.KnockBack();
    }
    private void AttackMotion()
    {
        HeroMove(10, 10);
    }
    public void KnockBack()
    {
        HeroMove(-5, -5);
    }
    public void LevelUp()
    {
        NowATK += 1;
        NowDEF += 1;
        Debug.Log("LevelUp! 攻撃力と防御力が1上がった");
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
