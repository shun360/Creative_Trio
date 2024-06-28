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
    private HeroClass hero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    private bool shouldMove = false;
    public void HeroMove(Vector3 target)
    {
        targetPosition = target;
        shouldMove = true;
    }
    public void goAttack(GameObject enemy)
    {
        Vector3 origin = transform.position;
        HeroMove(new Vector3(enemy.transform.position.x - 5, enemy.transform.position.y, 0));
        //enemyにpinの攻撃処理

        HeroMove(origin);
    }

    
    private void Awake()
    {
        hero = new HeroClass();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        
        transform.position = new Vector3(15, 15, 0);
        HeroMove(new Vector3(30,30,0));
        
    }


    // Update is called once per frame
    void Update()
    {
        if(shouldMove)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.7f);
            if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                shouldMove = false;
                velocity = Vector3.zero;
            }
        }
        if(hero.HeroNowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            //ゲームオーバー処理を書く
        }
    }
}
