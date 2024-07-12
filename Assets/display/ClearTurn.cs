using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearTurn : MonoBehaviour
{
    public TMP_Text turnText;
    void Start()
    {
        int turns = GameManager.Instance.sumTurn;
        turnText.text = $"�N���A�ɂ��������^�[�����F\n{turns}�^�[��";
    }
}
