using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleClass : MonsterClass
{
    public override void Init()
    {
        StatusSet(mt.Gargoyle, 300, 30, 20);
    }
    public override void Obstruction()
    {
        //TODO:3�^�[���̊ԁA�G���Ƃ��̃^�[��ATK-3�����G���A�����[���ɒu��
    }

    protected override List<List<mc>> ActSet()
    {
        List<List<mc>> actPattern = new List<List<mc>>();
        int cycle = 6;
        for (int i = 0; i < cycle; i++)
        {
            List<mc> act = new List<mc>();
            switch (i)
            {
                case 0:
                    act.Add(mc.Obstruction);
                    break;
                case 1:
                    act.Add(mc.Attack);
                    break;
                case 2:
                    act.Add(mc.Attack);
                    break;
                case 3:
                    act.Add(mc.Block);
                    act.Add(mc.Debuff);
                    break;
                case 4:
                    act.Add(mc.Attack);
                    break;
                case 5:
                    act.Add(mc.Attack);
                    break;


            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}