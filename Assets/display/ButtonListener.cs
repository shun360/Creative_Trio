using senceName;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("�{�^���R���|�[�l���g��������܂���ł���");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance��Null�ł�");
            return;
        }
        


    }

   
}
