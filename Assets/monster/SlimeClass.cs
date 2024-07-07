using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClass : MonsterClass
{
    public override void Init()
    {
        StatusSet(mt.Slime, 30, 11, 6);
    }
    protected override void LoadSprite(mt t)
    {
        sprite = Resources.Load<Sprite>(t.ToString());
        if (sprite == null)
        {
            Debug.LogError($"{t}のイメージが見つかりませんでした");
        }
    }
    protected override List<List<mc>> ActSet()
    {
        List<List<mc>> actPattern = new List<List<mc>>();
        int cycle = 2;
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
                    break;
            }
            actPattern.Add(act);
        }
        return actPattern;
    }


}