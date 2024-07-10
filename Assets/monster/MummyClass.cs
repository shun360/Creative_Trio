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
        StatusSet(thistype, 200, 36, 18);
    }
    public override IEnumerator Buff()
    {
        BuffATK(10);
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
                    act.Add(mc.Obstruction);
                    act.Add(mc.Block);
                    break;
                case 1:
                    act.Add(mc.Attack);
                    break;
                case 2:
                    act.Add(mc.Buff);
                    act.Add(mc.Block);
                    break;
                
            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}
