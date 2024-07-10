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
        int atk = 5;
        int def = 5;
        nowATK += atk;
        nowDEF += def;
        Debug.Log($"{thistype}ÇÃçUåÇóÕÇ™{atk}ÅAñhå‰óÕÇ™{def}è„Ç™ÇËÅAçUåÇóÕ{nowATK}ÅAñhå‰óÕ{nowDEF}Ç…Ç»ÇËÇ‹ÇµÇΩ");
        yield return new WaitForSeconds(1);//FixMe:ââèo
    }
    public override IEnumerator Debuff()
    {
        int atk = 2;
        int def = 2;
        HeroScript hero = FindObjectOfType<HeroScript>();
        hero.DebuffATK(atk);
        hero.DebuffDEF(def);
        yield return new WaitForSeconds(1); 
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
                    act.Add(mc.Debuff);
                    act.Add(mc.Block);
                    break;
                case 1:
                    act.Add(mc.Attack);
                    break;
                case 2:
                    act.Add(mc.Attack);
                    break;
                case 3:
                    act.Add(mc.Buff);
                    act.Add(mc.Block);
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
