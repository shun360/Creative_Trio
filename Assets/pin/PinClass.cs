using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class PinClass : MonoBehaviour
{
    private readonly float knockDownAngle = 30.0f;
    private bool isKnockDown; //倒れたかどうか
    private bool sentCommand; //コマンドを送ったかどうか
    public Material Attack;
    public Material Block;
    public Material Fire;
    public Material Smash;
    public Material Protection;
    public Material CurseATK;
    public Material Penetration;
    public Material ExtendATK;
    public Material EctendDEF;
    public Material TwiceAOE;
    public Material RandomTripleAttack;
    public Material OnlyOne;
    [SerializeField] public Ct Type { get; private set; }
    
    public void Init(Ct type)
    {
        isKnockDown = false;
        sentCommand = false;
        this.Type = type;
        Renderer r = GetComponent<Renderer>();
        Material[] materials = r.materials;
        switch (type)
        {
            case Ct.Attack:
                materials[0] = Attack;
                break;
            case Ct.Block:
                materials[0] = Block;
                break;
            case Ct.Fire:
                materials[0] = Fire;
                break;
            case Ct.Smash:
                materials[0] = Smash;
                break;
            case Ct.Protection:
                materials[0] = Protection;
                break;
            case Ct.CurseATK:
                materials[0] = CurseATK;
                break;
            case Ct.Penetration:
                materials[0] = Penetration;
                break;
            case Ct.ExtendATK:
                materials[0] = ExtendATK;
                break;
            case Ct.ExtendDEF:
                materials[0] = EctendDEF;
                break;
            case Ct.TwiceAOE:
                materials[0] = TwiceAOE;
                break;
            case Ct.RandomTripleAttack:
                materials[0] = RandomTripleAttack;
                break;
            case Ct.OnlyOne:
                materials[0] = OnlyOne;
                break;
        }
        r.materials = materials;

    }
    private void Send()
    {
        if (!sentCommand)
        {
            if (GameObject.Find("CommandQueue") != null)
            {
                GameObject.Find("CommandQueue").GetComponent<CommandQueue>().AddCommand(Type);
                sentCommand = true;
                Debug.Log($"{Type}をコマンドキューに送った");
                Remove();
            }
            
        }
        
    }
    public void Remove()
    {
        if(PinScript.pinYetSentList.Contains(gameObject)) 
        {
            PinScript.pinYetSentList.Remove(gameObject);
        }
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
            sentCommand = true;

        }
        if(transform.position.y < -1 && !sentCommand)
        {
            
            Send();
            sentCommand = true;
        }
        
    }
}
