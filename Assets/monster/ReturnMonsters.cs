using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class ReturnMonsters : MonoBehaviour
{
    public static List<List<Mt>> monsters; //stageごとに出現するモンスターを格納
    
    public List<Mt> StageMonsters(int stageNo) //stage番号(そのまま)を入れるとそのステージに出すモンスターlistを返す
    {
        if (0 < stageNo  && stageNo <= monsters.Count)
        {
            return monsters[stageNo - 1];
        }
        else
        {
            Debug.LogError("範囲外のステージが読み込まれました");
            return new List<Mt> { Mt.NoneMonster };
        }
    }
    void Awake()
    {
        monsters = new List<List<Mt>>//1つのステージにつき3体まで
        {
            new() { Mt.Slime, Mt.Slime }, //stage1
            new() { Mt.Bat, Mt.Slime },
            new() { Mt.Mummy },
            new() { Mt.Bat, Mt.Bat, Mt.Bat },
            new() { Mt.Gargoyle } //stage5(ボス)
        };
    }

    
}
