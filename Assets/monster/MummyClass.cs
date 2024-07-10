using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyClass : MonsterClass
{
    public override void Init()
    {
        thistype = mt.Mummy;
        Debug.Log("Mummy Init()");
        transform.localScale = new Vector3(8, 8, 1);
        StatusSet(thistype, 150, 25, 10);
    }
    public override IEnumerator Obstruction()
    {
        //TODO:2ターンの間レーンに3つ小さな石を出して妨害する。位置はランダム
        yield return null;
    }

    protected override List<List<mc>> ActSet()
    {
        List<List<mc>> actPattern = new List<List<mc>>();
        int cycle = 3;
        for (int i = 0; i < cycle; i++)
        {
            List<mc> act = new List<mc>();
            switch (i)
            {
                case 0:
                    act.Add(mc.Attack);
                    break;
                case 1:
                    act.Add(mc.Block);
                    act.Add(mc.Obstruction);
                    break;
                case 2:
                    act.Add(mc.Block);
                    act.Add(mc.Buff);
                    break;
                
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}
