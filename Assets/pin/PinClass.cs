using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinClass : MonoBehaviour
{
    private bool isKnockDown = false; //�|�ꂽ���ǂ���
    private bool sentCommand = false; //�R�}���h�𑗂������ǂ���
    public CommandType Type;
    private PinClass()
    {
        
    }
    private PinClass(CommandType type)
    {
        SetType(type);
    }
    public void SetType(CommandType type)
    {
        this.Type = type;
        Debug.Log($"�s����{type}���Z�b�g");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        if(isKnockDown && !sentCommand)
        {
            CommandQueue.AddCommand(Type);
            sentCommand = true;
            Debug.Log($"{Type}���R�}���h�L���[�ɑ�����");
        }


    }
}
