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
    public IEnumerator AllCommandsExe()
    {
        Debug.Log("コマンド実行開始");
        yield return new WaitForSeconds(1);
        
        while(commandQueue.Count > 0)
        {
            ct cmd = DequeueCommand();
            yield return ExecuteCommand(cmd);
        }
        Debug.Log("コマンド実行終了");
    }
    public IEnumerator ExecuteCommand(ct cmd)
    {
        if(MonsterScript.monList.Count > 0) 
        {
            switch (cmd)
            {
                case ct.Attack:
                    Debug.Log("攻撃を実行");
                    yield return hero.Attack();
                    break;
                case ct.Block:
                    Debug.Log("防御を実行");
                    //FixMe:防御エフェクト
                    yield return hero.AddBlock();
                    break;
                case ct.Fireball:
                    Debug.Log("炎魔法を実行");
                    //TODO:魔法を実装
                    yield return hero.Fireball();
                    break;
            }

        }
        else
        {
            Debug.Log("モンスターが全滅しました");
            ClearCommand();
            yield return null;
        }
        
    }

    public void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        commandQueue = new List<ct>();
        hero = FindObjectOfType<HeroScript>();

    }
    
    
}
