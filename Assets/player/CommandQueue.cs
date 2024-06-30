using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandQueue : MonoBehaviour
{
    private static Queue<CommandType> commandQueue;
    public static void AddCommand(CommandType cmd) {  commandQueue.Enqueue(cmd); }
    public static CommandType dequeueCommand() { return commandQueue.Dequeue(); }
    public static void AllCommandsExe()
    {
        while(commandQueue.Count > 0)
        {
            CommandType cmd = commandQueue.Dequeue();
            ExecuteCommand(cmd);
        }
    }
    public static void ExecuteCommand(CommandType cmd)
    {
        switch (cmd)
        {
            case CommandType.Attack:
                Debug.Log("アタック実行");
                //攻撃を実装
                break;
            case CommandType.Block:
                Debug.Log("防御実行");
                //防御を実装
                break;
            case CommandType.Fireboll:
                Debug.Log("ファイアボール実行");
                //魔法を実行
                break;
        }
    }

    public static void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        if(commandQueue == null)
        {
            commandQueue = new Queue<CommandType>();
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
