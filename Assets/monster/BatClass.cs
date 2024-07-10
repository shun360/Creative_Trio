using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatClass : MonsterClass
{
    public override void Init()
    {
        thistype = mt.Bat;
        StatusSet(thistype, 80, 18, 0);
    }
    protected override List<List<mc>> ActSet()
    {
        List<List<mc>> actPattern = new List<List<mc>>();
        int cycle = 1;
        for (int i = 0; i < cycle; i++)
        {
            List<mc> act = new List<mc>();
            switch (i)
            {
                case 0:
                    act.Add(mc.Attack);
                    break;
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}
