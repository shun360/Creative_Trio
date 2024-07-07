using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyClass : MonsterClass
{
    public override void Init()
    {
        StatusSet(mt.Mummy, 150, 25, 10);
    }
    public override void Obstruction()
    {
        //TODO:2�^�[���̊ԃ��[����3�����Ȑ΂��o���ĖW�Q����B�ʒu�̓����_��
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
