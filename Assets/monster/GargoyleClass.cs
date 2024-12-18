using MonsterSet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleClass : MonsterClass
{
    public override void Init()
    {
        thistype = Mt.Gargoyle;
        scale = 10;
        transform.localScale = new Vector3(scale, scale, 1);
        StatusSet(thistype, 500, 42, 25);
    }
    protected override float CalcActUIOffset()
    {
        return 140;
    }
    public override IEnumerator Buff()
    {
        if(GameManager.Instance.turn < 12)
        {
            yield return BuffATK(10);
            yield return BuffDEF(10);
        }
        else
        {
            yield return BuffATK(50);
            yield return BuffDEF(30);
        }
    }
    public override IEnumerator Debuff()
    {
        HeroScript hero = FindObjectOfType<HeroScript>();
        yield return hero.DebuffATK(3);
        yield return hero.DebuffDEF(3);
    }
    public override IEnumerator Obstruction()
    {
        WallScript wall = FindObjectOfType<WallScript>();
        wall.active = true;
        StartCoroutine(ef.ObsEffect(hero.transform.position));
        Debug.Log("Gargoyleの妨害！レーンに動く壁が出るようになった");

        actPattern[0] = new List<Mc> { Mc.Attack };
        yield return new WaitForSeconds(1);
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
