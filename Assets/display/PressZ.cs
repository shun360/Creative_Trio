using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressZ : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    private void Awake()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        Hide();
    }
    public void Hide(){
        tmpro.color = new Color(1, 1, 1, 0);
    }
    public void Show()
    {
        tmpro.color = new Color(1, 1, 1, 1);
    }
}
