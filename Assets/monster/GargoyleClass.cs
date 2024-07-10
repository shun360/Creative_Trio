using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleClass : MonsterClass
{
    public override void Init()
    {
        thistype = mt.Gargoyle;
        transform.localScale = new Vector3(10, 10, 1);
        StatusSet(thistype, 500, 30, 20);
    }
    public override IEnumerator Buff()
    {
        BuffATK(10);
        BuffDEF(10);
        yield return new WaitForSeconds(1);
    }
    public override IEnumerator Debuff()
    {
        HeroScript hero = FindObjectOfType<HeroScript>();
        hero.DebuffATK(3);
        hero.DebuffDEF(3);
        yield return new WaitForSeconds(1); 
    }
    public override IEnumerator Obstruction()
    {
        WallScript wall = FindObjectOfType<WallScript>();
        if (!wall.active)
        {
            wall.active = true;
            Debug.Log("GargoyleÇÃñWäQÅIÉåÅ[ÉìÇ…ìÆÇ≠ï«Ç™èoÇÈÇÊÇ§Ç…Ç»Ç¡ÇΩ");
            yield return new WaitForSeconds(1);
        }
        else
        {
           yield return Attack();
        }
        yield return null;
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
                    act.Add(mc.Debuff);
                    act.Add(mc.Block);
                    break;
                case 2:
                    act.Add(mc.Attack);
                    break;
                case 3:
                    act.Add(mc.Attack);
                    break;
                case 4:
                    act.Add(mc.Buff);
                    act.Add(mc.Block);
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
