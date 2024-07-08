using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class CommandQueue : MonoBehaviour
{
    private HeroScript hero;
    public List<ct> commandQueue;
    public void AddCommand(ct cmd) {  commandQueue.Add(cmd); }
    public ct DequeueCommand() 
    {
        ct c = commandQueue[0];
        commandQueue.RemoveAt(0);
        return c; 
    }
    public void AllCommandsExe()
    {
        while(commandQueue.Count > 0)
        {
            ct cmd = DequeueCommand();
            ExecuteCommand(cmd);
        }
    }
    public void ExecuteCommand(ct cmd)
    {
        switch (cmd)
        {
            case ct.Attack:
                Debug.Log("アタック実行");
                //攻撃を実装
                if(hero != null)
                {
                    hero.AttackMotion();
                }
                break;
            case ct.Block:
                Debug.Log("防御実行");
                //防御を実装
                
                break;
            case ct.Fireball:
                Debug.Log("ファイアボール実行");
                //魔法を実行
                break;
        }//コルーチンを書く
        
    }

    public void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        commandQueue = new List<ct>();
        Debug.Log("キュー生成");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (hero == null)
        {
            hero = FindObjectOfType<HeroScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
