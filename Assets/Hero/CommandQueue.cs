using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class CommandQueue : MonoBehaviour
{
    private HeroScript hero;
    public List<Ct> commandQueue;
    public void AddCommand(Ct cmd) {  commandQueue.Add(cmd); }
    public Ct DequeueCommand() 
    {
        Ct c = commandQueue[0];
        commandQueue.RemoveAt(0);
        return c; 
    }
    public IEnumerator AllCommandsExe()
    {
        Debug.Log("コマンド実行開始");
        yield return new WaitForSeconds(1);
        
        while(commandQueue.Count > 0)
        {
            Ct cmd = DequeueCommand();
            yield return ExecuteCommand(cmd);
        }
        Debug.Log("コマンド実行終了");
    }
    public IEnumerator ExecuteCommand(Ct cmd)
    {
        if(MonsterScript.monList.Count > 0) 
        {
            switch (cmd)
            {
                case Ct.Attack:
                    Debug.Log($"{cmd}攻撃を実行");
                    yield return hero.Attack();
                    break;
                case Ct.Block:
                    Debug.Log($"{cmd}防御を実行");
                    //FixMe:防御エフェクト
                    yield return hero.AddBlock();
                    break;
                case Ct.Fireball:
                    Debug.Log($"{cmd}を実行");
                    //FixMe:エフェクト
                    yield return hero.Fireball();
                    break;
                case Ct.DoubleAttack:
                    Debug.Log($"{cmd}を実行");
                    //yield return hero.();
                    break;
                case Ct.DoubleBlock:
                    Debug.Log($"{cmd}を実行");
                    //yield return hero.();
                    break;
                case Ct.DebuffATK:
                    Debug.Log($"{cmd}を実行");
                    //yield return hero.();
                    break;
                case Ct.DebuffDEF:
                    Debug.Log($"{cmd}を実行");
                    //yield return hero.();
                    break;
                case Ct.BuffATK:
                    Debug.Log($"{cmd}を実行");
                    yield return hero.BuffATK(2);
                    break;
                case Ct.BuffDEF:
                    Debug.Log($"{cmd}を実行");
                    yield return hero.BuffDEF(2);
                    break;
                case Ct.TwiceAOE:
                    Debug.Log($"{cmd}を実行");
                    //yield return hero.();
                    break;
                case Ct.RandomTwiceAttack:
                    Debug.Log($"{cmd}を実行");
                    //yield return hero.();
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
        commandQueue = new List<Ct>();
        hero = FindObjectOfType<HeroScript>();

    }
    
    
}
