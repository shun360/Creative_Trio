using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClass : MonsterClass
{
    public override void Init()
    {
        thistype = Mt.Slime;
        StatusSet(Mt.Slime, 30, 7, 10);
    }
   
    protected override List<List<Mc>> ActSet()
    {
        List<List<Mc>> actPattern = new List<List<Mc>>();
        int cycle = 2;
        for (int i = 0; i < cycle; i++)
        {
            List<Mc> act = new List<Mc>();
            switch (i)
            {
                case 0:
                    act.Add(Mc.Attack);
                    break;
                case 1:
                    act.Add(Mc.Block);
                    break;
            }
            actPattern.Add(act);
        }
        return actPattern;
    }


}