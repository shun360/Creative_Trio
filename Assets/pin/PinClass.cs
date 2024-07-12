using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class PinClass : MonoBehaviour
{
    private float knockDownAngle = 30.0f;
    private bool isKnockDown = false; //�|�ꂽ���ǂ���
    private bool sentCommand = false; //�R�}���h�𑗂������ǂ���
    [SerializeField] public Ct Type { get; private set; }
    public PinClass()
    {
        
    }
    public void Init(Ct type)
    {
        this.Type = type;
        //TODO:�����ɐF����
        
    }
    private void Send()
    {
        if (!sentCommand)
        {
            GameObject.Find("CommandQueue").GetComponent<CommandQueue>().AddCommand(Type);
            sentCommand = true;
            Debug.Log($"{Type}���R�}���h�L���[�ɑ�����");
            Remove();
        }
        
    }
    public void Remove()
    {
        if(PinScript.pinYetSentList.Contains(gameObject)) 
        {
            PinScript.pinYetSentList.Remove(gameObject);
        }
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
            Send();
            
        }
        if(transform.position.y < -1 && !sentCommand)
        {
            
            Send();
        }
        
    }
}
