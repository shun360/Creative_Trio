using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class ClearTurn : MonoBehaviour
{
    void Start()
    {
        int turns = GameManager.Instance.sumTurn;
        GetComponent<Text>().text = $"クリアにかかったターン数：\n{turns}ターン";
        UnityroomApiClient.Instance.SendScore(1, turns, ScoreboardWriteMode.HighScoreAsc);

    }
}
