using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandQueue : MonoBehaviour
{
    private HeroScript hero;
    public List<CommandType> commandQueue;
    public void AddCommand(CommandType cmd) {  commandQueue.Add(cmd); }
    public CommandType DequeueCommand() 
    {
        CommandType c = commandQueue[0];
        commandQueue.RemoveAt(0);
        return c; 
    }
    public IEnumerator AllCommandsExe()
    {
        Debug.Log("コマンドキュー実行開始");
        yield return new WaitForSeconds(1);
        
        while(commandQueue.Count > 0)
        {
            CommandType cmd = DequeueCommand();
            ExecuteCommand(cmd);
        }
    }
    public IEnumerator ExecuteCommand(CommandType cmd)
    {
        switch (cmd)
        {
            case CommandType.Attack:
                Debug.Log("アタック実行");
                //TODO：攻撃を実装
                if(hero != null)
                {
                    hero.Attack();
                }
                break;
            case CommandType.Block:
                Debug.Log("防御実行");
                //TODO：防御を実装
                hero.AddBlock();
                break;
            case CommandType.Fireball:
                Debug.Log("ファイアボール実行");
                //TODO:魔法を実行
                break;
        }
        yield return new WaitForSeconds(1);
    }

    public void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        commandQueue = new List<CommandType>();
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
