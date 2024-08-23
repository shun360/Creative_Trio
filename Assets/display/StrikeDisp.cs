using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StrikeDisp : MonoBehaviour
{
    private Image img;
    private TextMeshProUGUI tmpro;
    private void Awake()
    {
        img = GetComponent<Image>();
        tmpro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        Hide();
    }
    public void Hide()
    {
        img.color = new Color(0.3f, 0.85f, 1, 0);
        tmpro.color = new Color(1, 1, 1, 0);
        //SetActive()を使うと、GameManagerからコルーチンを呼び出せなくなる。
    }
    public IEnumerator Show()
    {        img.color = new Color(0.3f, 0.85f, 1, 1);
        tmpro.color = new Color(1, 1, 1, 1);
        yield return new WaitUntil (() => GameManager.Instance.throwEnd);
        Hide();
    }
}
