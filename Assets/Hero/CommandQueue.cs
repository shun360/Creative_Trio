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
        Debug.Log("�R�}���h�L���[���s�J�n");
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
                Debug.Log("�A�^�b�N���s");
                //TODO�F�U��������
                if(hero != null)
                {
                    hero.Attack();
                }
                break;
            case CommandType.Block:
                Debug.Log("�h����s");
                //TODO�F�h�������
                hero.AddBlock();
                break;
            case CommandType.Fireball:
                Debug.Log("�t�@�C�A�{�[�����s");
                //TODO:���@�����s
                break;
        }
        yield return new WaitForSeconds(1);
    }

    public void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        commandQueue = new List<CommandType>();
        Debug.Log("�L���[����");
        
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
