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
        StatusSet(thistype, 200, 35, 18);
    }
    public override IEnumerator Buff()
    {
        int atk = 10;
        nowATK += atk; 
        Debug.Log($"{thistype}のATKが{atk}上がり、{nowATK}になりました");
        yield return new WaitForSeconds(1);//FixMe:演出 
    }
    public override IEnumerator Obstruction()
    {
        MummyStone stone = FindObjectOfType<MummyStone>();
        if (!stone)
        {
            stone.mummyObs = true;
            Debug.Log("Mummyの妨害！レーンに石が出るようになる！");
        }
        yield return new WaitForSeconds(1);
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
                    act.Add(mc.Obstruction);
                    act.Add(mc.Block);
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
