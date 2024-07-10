using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class PinClass : MonoBehaviour
{
    private float knockDownAngle = 60.0f;
    private bool isKnockDown = false; //倒れたかどうか
    private bool sentCommand = false; //コマンドを送ったかどうか
    [SerializeField] public ct Type { get; private set; }
    public PinClass()
    {
        
    }
    public void Init(ct type)
    {
        this.Type = type;
        
    }
    private void Send()
    {
        if (!sentCommand)
        {
            GameObject.Find("CommandQueue").GetComponent<CommandQueue>().AddCommand(Type);
            sentCommand = true;
            Debug.Log($"{Type}をコマンドキューに送った");
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
