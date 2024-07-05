using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinClass : MonoBehaviour
{
    private bool isKnockDown = false; //�|�ꂽ���ǂ���
    private bool sentCommand = false; //�R�}���h�𑗂������ǂ���
    [SerializeField] public CommandType Type { get; private set; }
    public PinClass()
    {
        
    }
    public void Init(CommandType type)
    {
        this.Type = type;
        Debug.Log($"�s����{type}���Z�b�g");
    }
    private void Send()
    {
        if (!sentCommand)
        {
            GameObject.Find("CommandQueue").GetComponent<CommandQueue>().AddCommand(Type);
            sentCommand = true;
            Debug.Log($"{Type}���R�}���h�L���[�ɑ�����");
        }
        
    }
    public void Remove()
    {
        //�����鉉�o��ǉ��H
        Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        if(isKnockDown)
        {
            Send();
        }
        if(transform.position.y < -5)
        {
            Send();
            Remove();
        }

    }
}
