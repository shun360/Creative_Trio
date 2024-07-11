using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatClass : MonsterClass
{
    public override void Init()
    {
        thistype = Mt.Bat;
        StatusSet(thistype, 80, 18, 0);
    }
    protected override List<List<Mc>> ActSet()
    {
        List<List<Mc>> actPattern = new List<List<Mc>>();
        int cycle = 1;
        for (int i = 0; i < cycle; i++)
        {
            List<Mc> act = new List<Mc>();
            switch (i)
            {
                case 0:
                    act.Add(Mc.Attack);
                    break;
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}
