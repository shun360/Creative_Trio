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
            ExecuteCommand(cmd);
        }
    }
    public IEnumerator ExecuteCommand(ct cmd)
    {
        switch (cmd)
        {
            case ct.Attack:
                Debug.Log("攻撃を実行");
                //TODO:攻撃を実装
                if(hero != null)
                {
                    StartCoroutine(hero.Attack());
                }
                break;
            case ct.Block:
                Debug.Log("防御を実行");
                //TODO:防御を実装
                hero.AddBlock();
                break;
            case ct.Fireball:
                Debug.Log("炎魔法を実行");
                //TODO:魔法を実装
                break;
        }
        yield return new WaitForSeconds(1);
    }

    public void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        commandQueue = new List<ct>();
        
        
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
