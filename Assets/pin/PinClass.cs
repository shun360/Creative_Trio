using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinClass : MonoBehaviour
{
    private bool isKnockDown = false; //倒れたかどうか
    private bool sentCommand = false; //コマンドを送ったかどうか
    //private static Vector3 fp = new Vector3(-100, 1, 70);//基準の位置・使わないかも
    private static Vector3[] positions =
    {
        new Vector3(0, 0, 0),
        new Vector3(-0.5f, 0, 1),
        new Vector3(0.5f, 0, 1),
        new Vector3(-1, 0, 2),
        new Vector3(0, 0, 2),
        new Vector3(1, 0, 2),
        new Vector3(-1.5f, 0, 3),
        new Vector3(-0.5f, 0, 3),
        new Vector3(0.5f, 0, 3),
        new Vector3(1.5f, 0, 3),
    };
    public CommandType Type {  get; private set; }
    public PinClass(CommandType type)
    {
        this.Type = type;
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
            Debug.Log($"{Type}をコマンドキューに送った");
        }


    }
}
