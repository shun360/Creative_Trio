using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinClass : MonoBehaviour
{
    private float knockDownAngle = 60.0f;
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
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (knockDownAngle < Vector3.Angle(Vector3.up, transform.up))
        {
            isKnockDown = true;
        }
        if(isKnockDown && !sentCommand)
        {
            Debug.Log("60�x�ȏ�ɌX����");
            Send();
            
        }
        if(transform.position.y < -1 && !sentCommand)
        {
            Debug.Log("y��-1�����ɂȂ���");
            Send();
        }
        
    }
}
