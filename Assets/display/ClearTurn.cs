using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearTurn : MonoBehaviour
{
    void Start()
    {
        int turns = GameManager.Instance.sumTurn;
        GetComponent<TMP_Text>().text = $"クリアにかかったターン数：\n{turns}ターン";
    }
}
