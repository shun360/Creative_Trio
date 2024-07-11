using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleClass : MonsterClass
{
    public override void Init()
    {
        thistype = Mt.Gargoyle;
        transform.localScale = new Vector3(10, 10, 1);
        StatusSet(thistype, 500, 42, 25);
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

    protected override List<List<Mc>> ActSet()
    {
        List<List<Mc>> actPattern = new List<List<Mc>>();
        int cycle = 6;
        for (int i = 0; i < cycle; i++)
        {
            List<Mc> act = new List<Mc>();
            switch (i)
            {
                case 0:
                    act.Add(Mc.Obstruction);
                    break;
                case 1:
                    act.Add(Mc.Attack);
                    break;
                case 2:
                    act.Add(Mc.Debuff);
                    act.Add(Mc.Block);
                    break;
                case 3:
                    act.Add(Mc.Attack);
                    break;
                case 4:
                    act.Add(Mc.Attack);
                    break;
                case 5:
                    act.Add(Mc.Buff);
                    act.Add(Mc.Block);
                    break;


            }
            actPattern.Add(act);
        }
        return actPattern;
    }
}
