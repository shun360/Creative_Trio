using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class MonsterScript : MonoBehaviour
{
    public GameObject monPrefab;
    public static List<GameObject> monList;
    private static readonly Vector3 p = new(65, 75, 0);
    private static readonly Vector3[] positions =
    {
        p,
        new(p.x + 20, p.y - 15, p.z),
        new(p.x - 25, p.y + 10, p.z)
    };
    private void Awake()
    {
        monPrefab = (GameObject)Resources.Load("Monster");
        monList = new List<GameObject>();

    }
    public IEnumerator ArrangeMonsters(List<Mt> mts)
    {
        　
        for (int i = 0; i < mts.Count; i++)
        {
            GameObject monstance = Instantiate(monPrefab, positions[i], Quaternion.identity);
            Debug.Log("モンスター生成");
            
            switch (mts[i]){
                case Mt.Slime:
                    monstance.AddComponent<SlimeClass>().Init();
                    break;
                case Mt.Bat:
                    monstance.AddComponent<BatClass>().Init();
                    break;
                case Mt.Mummy:
                    monstance.AddComponent<MummyClass>().Init();
                    break;
                case Mt.Gargoyle:
                    monstance.AddComponent<GargoyleClass>().Init();
                    break;
                default:
                    monstance.AddComponent<MonsterClass>().Init();
                    break;
                    
            }
            monList.Add(monstance);
        }
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<TargetDisplay>().DispTarget();
        
    }
    public void SetMonster()
    {
        StartCoroutine(ArrangeMonsters(FindObjectOfType<ReturnMonsters>().StageMonsters(GameManager.Instance.stageNo)));
    }

    public IEnumerator MonstersAct()
    {
        if(monList.Count > 0)
        {
            Debug.Log("モンスター行動開始");
            yield return new WaitForSeconds(1);
            for (int i = 0; i < monList.Count; i++)
            {
                if (monList[i] != null)
                {
                    yield return monList[i].GetComponent<MonsterClass>().Act();
                }
                else
                {
                    Debug.LogWarning("モンスターの参照が切れました");
                }
                
            }
            Debug.Log("モンスター行動終了");
        }
        yield return null;
    }
    public void ActScheduleDisp()
    {
        for (int i = 0; i < monList.Count; i++)
        {
                monList[i].GetComponent<MonsterClass>().ActScheduleSet();
        }
    }
    public void TakeAOE(int damage)
    {
        for(int i = 0;i < monList.Count;i++)
        {
            monList[i].GetComponent<MonsterClass>().TakeAttacked(damage);
        }
    }
    public void AllDebuffATK(int amount)
    {
        for(int i = 0;i < monList.Count; i++)
        {
            StartCoroutine(monList[i].GetComponent<MonsterClass>().DebuffATK(amount));
        }
    }
    
    public void DeleteMonsters()
    {
        for (int i = monList.Count - 1; i >= 0; i--)
        {
            StartCoroutine(monList[i].GetComponent<MonsterClass>().Dead());
        }
        FindObjectOfType<HeroScript>().targetNumber = 0;
    }
    public void AllBlockZero()
    {
        for(int i = 0;i < monList.Count; i++)
        {
            monList[i].GetComponent<MonsterClass>().BlockZero();
        }
        Debug.Log("Monsterすべてのブロック値を0にしました");
    }
    
    
}
