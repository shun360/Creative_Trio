using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;
using UnityEngine.UI;
using TMPro;

public class ActSchedule : MonoBehaviour
{
    GameObject textObj;
    string text = "";
    public void ActDisp(Mc mc, int amount = -1)
    {
        textObj = transform.Find("AmountText").gameObject;
        if (amount >= 0)
        {
            GetComponent<RectTransform>().position += new Vector3(-6, 0, 0);
            textObj.GetComponent<RectTransform>().position += new Vector3(1, 0, 0);
            text = amount.ToString();
            textObj.GetComponent<TextMeshProUGUI>().text = text;
        }
        else
        {
            textObj.GetComponent<TextMeshProUGUI>().text = "";
        }
        string prefabName = "None";
        switch (mc)
        {
            case Mc.Attack:
                prefabName = "AttackIcon";
                break;
            case Mc.Block:
                prefabName = "BlockIcon";
                break;
            case Mc.Buff:
                prefabName = "UpMonster";
                break;
            case Mc.Debuff:
                prefabName = "DownMonster";
                break;
            case Mc.Obstruction:
                prefabName = "SoulIcon";
                break;
        }
        GameObject prefab = (GameObject)Resources.Load($"{prefabName}");
        GameObject obj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
    }
    public void AmountUpdate(int amount)
    {
        if(text != "")
        {
            textObj.GetComponent<TextMeshProUGUI>().text = amount.ToString();
        }
    }

}
