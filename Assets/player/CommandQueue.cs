using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandQueue : MonoBehaviour
{
    private Queue<CommandType> commandQueue = new Queue<CommandType>();
    public void addCommand(CommandType cmd) {  commandQueue.Enqueue(cmd); }
    public CommandType dequeueCommand() { return commandQueue.Dequeue(); }
    public void allCommandsExe()
    {
        while(commandQueue.Count > 0)
        {
            CommandType cmd = commandQueue.Dequeue();
            ExecuteCommand(cmd);
        }
    }
    public void ExecuteCommand(CommandType cmd)
    {
        switch (cmd)
        {
            case CommandType.Attack:
                Debug.Log("アタック実行");
                //攻撃を実装
                break;
            case CommandType.Defense:
                Debug.Log("防御実行");
                //防御を実装
                break;
            case CommandType.Fireboll:
                Debug.Log("ファイアボール実行");
                break;
        }
    }

    public void clearCommand() { commandQueue.Clear(); }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
