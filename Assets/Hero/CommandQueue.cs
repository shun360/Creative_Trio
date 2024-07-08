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
                Debug.Log("�A�^�b�N���s");
                //�U��������
                if(hero != null)
                {
                    hero.AttackMotion();
                }
                break;
            case ct.Block:
                Debug.Log("�h����s");
                //�h�������
                
                break;
            case ct.Fireball:
                Debug.Log("�t�@�C�A�{�[�����s");
                //���@�����s
                break;
        }//�R���[�`��������
        
    }

    public void ClearCommand() { commandQueue.Clear(); }
    private void Awake()
    {
        commandQueue = new List<ct>();
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
