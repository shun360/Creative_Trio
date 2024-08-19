using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;
using UnityEngine.UI;
using TMPro;

public class ActSchedule : MonoBehaviour
{
    public void ActDisp(Mc mc, int amount = -1)
    {
        GameObject textObj = transform.Find("AmountText").gameObject;
        if (amount >= 0)
        {
            GetComponent<RectTransform>().position += new Vector3(-6, 0, 0);
            textObj.GetComponent<RectTransform>().position += new Vector3(1, 0, 0);
            textObj.GetComponent<TextMeshProUGUI>().text = amount.ToString();
        }
        else
        {
            textObj.GetComponent<TextMeshProUGUI>().text = "";
        }
        string prefabName = "NoneMonster";
        switch (mc)
        {
            case Mc.Attack:
                prefabName = "AttackPlan";
                break;
            case Mc.Block:
                prefabName = "BlockPlan";
                break;
            case Mc.Buff:
                prefabName = "BuffPlan";
                break;
            case Mc.Debuff:
                prefabName = "DebuffPlan";
                break;
            case Mc.Obstruction:
                prefabName = "ObstructionPlan";
                break;
        }
        GameObject prefab = (GameObject)Resources.Load($"{prefabName}");
        GameObject obj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;

        //Todo:mc‚ÌŽí—Þ‚ð‚à‚Æ‚É•\Ž¦
    }


}
