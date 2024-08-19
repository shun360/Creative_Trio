using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyClass : MonsterClass
{
    public override void Init()
    {
        thistype = Mt.Mummy;
        scale = 8;
        transform.localScale = new Vector3(scale, scale, 1);
        StatusSet(thistype, 200, 27, 16);
    }
    public override IEnumerator Buff()
    {
        StartCoroutine(BuffATK(8));
        yield return new WaitForSeconds(1);
    }
    public override IEnumerator Obstruction()
    {
        MummyStone stone = FindObjectOfType<MummyStone>();
        stone.active = true;
        StartCoroutine(ef.ObsEffect(hero.transform.position));
        Debug.Log("MummyÇÃñWäQÅIÉåÅ[ÉìÇ…êŒÇ™èoÇÈÇÊÇ§Ç…Ç»Ç¡ÇΩ");
        actPattern[0] = new List<Mc>{ Mc.Buff, Mc.Block };
        yield return new WaitForSeconds(1);
    }

    protected override List<List<Mc>> ActSet()
    {
        List<List<Mc>> actPattern = new List<List<Mc>>();
        int cycle = 3;
        for (int i = 0; i < cycle; i++)
        {
            List<Mc> act = new List<Mc>();
            switch (i)
            {
                case 0:
                    act.Add(Mc.Obstruction);
                    act.Add(Mc.Block);
                    break;
                case 1:
                    act.Add(Mc.Attack);
                    break;
                case 2:
                    act.Add(Mc.Buff);
                    act.Add(Mc.Block);
                    break;
                
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}
