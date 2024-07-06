using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinClass : MonoBehaviour
{
    private float knockDownAngle = 60.0f;
    private bool isKnockDown = false; //倒れたかどうか
    private bool sentCommand = false; //コマンドを送ったかどうか
    [SerializeField] public CommandType Type { get; private set; }
    public PinClass()
    {
        
    }
    public void Init(CommandType type)
    {
        this.Type = type;
        Debug.Log($"ピンに{type}をセット");
    }
    private void Send()
    {
        if (!sentCommand)
        {
            GameObject.Find("CommandQueue").GetComponent<CommandQueue>().AddCommand(Type);
            sentCommand = true;
            Debug.Log($"{Type}をコマンドキューに送った");
            
        }
        
    }
    public void Remove()
    {
        //消える演出を追加？
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
            Debug.Log("60度以上に傾いた");
            Send();
            
        }
        if(transform.position.y < -1 && !sentCommand)
        {
            Debug.Log("yが-1未満になった");
            Send();
        }
        
    }
}
