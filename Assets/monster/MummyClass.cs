using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyClass : MonsterClass
{
    public override void Init()
    {
        thistype = Mt.Mummy;
        transform.localScale = new Vector3(8, 8, 1);
        StatusSet(thistype, 200, 31, 18);
    }
    public override IEnumerator Buff()
    {
        BuffATK(8);
        yield return new WaitForSeconds(1);
    }
    public override IEnumerator Obstruction()
    {
        MummyStone stone = FindObjectOfType<MummyStone>();
        if (!stone.active)
        {
            stone.active = true;
            Debug.Log("MummyÇÃñWäQÅIÉåÅ[ÉìÇ…êŒÇ™èoÇÈÇÊÇ§Ç…Ç»Ç¡ÇΩ");
            yield return new WaitForSeconds(1);
        }
        else
        {
            yield return Buff();
        }
        yield return null;
        
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
