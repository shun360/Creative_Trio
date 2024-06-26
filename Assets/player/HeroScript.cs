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
    public HeroClass player = HeroScript.AddComponent<HeroClass>();//ChatGPTに聞いている

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        transform.position = new Vector3(15, 15, 0);
        player.HeroMove(new Vector3(30,30,0));
    }


    // Update is called once per frame
    void Update()
    {
        
        if(player.HeroNowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            //ゲームオーバー処理を書く
        }
    }
}
