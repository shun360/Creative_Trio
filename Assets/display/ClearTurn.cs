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
        GetComponent<Text>().text = $"�N���A�ɂ��������^�[�����F\n{turns}�^�[��";
        UnityroomApiClient.Instance.SendScore(1, turns, ScoreboardWriteMode.HighScoreAsc);

    }
}
