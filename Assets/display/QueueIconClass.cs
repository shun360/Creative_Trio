using CommandType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueIconClass : MonoBehaviour
{
    private QueueDisplay queueDisp;
    private Vector3 velocity;
    float seconds;
    float freq;
    public void Awake()
    {
        velocity = Vector3.zero;
        queueDisp = FindObjectOfType<QueueDisplay>();
        seconds = 0.5f;
        freq = 0.01f;
        
    }
    public void IconSet(Ct ct)
    {
        string prefabName = "";
        string ghostPrefabName = "";
        switch (ct)
        {
            case Ct.Attack:
                prefabName = "AttackIcon";
                break;
            case Ct.Block:
                prefabName = "BlockIcon";
                break;
            case Ct.Fire:
                prefabName = "Fire2";
                break;
            case Ct.Smash:
                prefabName = "Smash";
                break;
            case Ct.Protection:
                prefabName = "Protection";
                break;
            case Ct.CurseATK:
                prefabName = "CurseSword";
                ghostPrefabName = "DebuffIcon";
                break;
            case Ct.Penetration:
                prefabName = "Penetration";
                break;
            case Ct.ExtendATK:
                prefabName = "AttackIcon";
                ghostPrefabName = "BuffIcon";
                break;
            case Ct.ExtendDEF:
                prefabName = "BlockIcon";
                ghostPrefabName = "BuffIcon";
                break;
            case Ct.TwiceAOE:
                prefabName = "TwiceAOE";
                break;
            case Ct.RandomTripleAttack:
                prefabName = "RandomTripleAttack";
                break;
            case Ct.OnlyOne:
                prefabName = "OnlyOne";
                break;
        }
        if(prefabName == "")
        {
            prefabName = "None";
            Debug.LogWarning("QueueIconのプレハブが割り当てられませんでした。");
        }
        GameObject prefab = (GameObject)Resources.Load($"{prefabName}");
        GameObject obj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
        if(ghostPrefabName != "")
        {
            GameObject ghostprefab = (GameObject)Resources.Load($"{ghostPrefabName}");
            GameObject ghostobj = Instantiate(ghostprefab, this.transform.position, Quaternion.identity);
            ghostobj.transform.parent = this.transform;
            ghostobj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.9f);
        }
        
    }
    
    public IEnumerator Right(float dist)
    {
        Vector3 target = new Vector3(transform.position.x + dist , transform.position.y, transform.position.z);
        
        for(float i = seconds; i >= 0; i -= freq)
        {
            if (this == null || transform == null)
            {
                yield break;
            }
            float xTrans = dist / (seconds / freq);
            transform.Translate(xTrans, 0, 0);
            yield return new WaitForSeconds(freq);
        }
        
    }
}
