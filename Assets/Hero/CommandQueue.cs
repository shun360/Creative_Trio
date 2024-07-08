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
        Debug.Log("�R�}���h�L���[���s�J�n");
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
                Debug.Log("�A�^�b�N���s");
                //TODO�F�U��������
                if(hero != null)
                {
                    hero.Attack();
                }
                break;
            case ct.Block:
                Debug.Log("�h����s");
                //TODO�F�h�������
                hero.AddBlock();
                break;
            case ct.Fireball:
                Debug.Log("�t�@�C�A�{�[�����s");
                //TODO:���@�����s
                break;
        }
        yield return new WaitForSeconds(1);
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
