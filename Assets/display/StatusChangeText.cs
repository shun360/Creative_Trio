using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using StatusChangeType;
using TMPro;

namespace StatusChangeType
{
    public enum Ab
    {
        Attack,
        Defense,
        Block,
        MagiAttack
    }
    public enum Im
    {
        NoneUp,
        NoneDown,
        Up,
        Down
    }
}

public class StatusChangeText : MonoBehaviour
{
    public GameObject textPrefab; // TextMeshPro用のプレハブを設定する
    public GameObject upArrow;
    public GameObject downArrow;

    private void Awake()
    {
        textPrefab = (GameObject)Resources.Load("StatusChangeText");
        upArrow = (GameObject)Resources.Load("Up");
        downArrow = (GameObject)Resources.Load("Down");
    }

    public void ShowStatusChange(Vector3 pos, string txt, Im img, Ab type)
    {
        GameObject textObj = Instantiate(textPrefab, pos, Quaternion.identity, transform);
        TextMeshProUGUI uiText = textObj.GetComponent<TextMeshProUGUI>();

        uiText.text = txt;

        // typeに基づいてアウトラインの色を設定
        switch (type)
        {
            case Ab.Attack:
                uiText.outlineColor = Color.red;
                break;
            case Ab.Defense:
                uiText.outlineColor = Color.blue;
                break;
            case Ab.Block:
                uiText.outlineColor = Color.cyan;
                break;
            case Ab.MagiAttack:
                uiText.outlineColor = Color.magenta;
                break;
        }
        uiText.outlineWidth = 0.3f; // アウトラインの幅を設定

        if (img == Im.Up || img == Im.Down)
        {
            StartCoroutine(ShowArrowAndFadeOut(textObj, img, type));
        }
        else
        {
            StartCoroutine(FadeOutText(textObj, img));
        }
    }

    private IEnumerator FadeOutText(GameObject textObj, Im imgType)
    {
        TextMeshProUGUI uiText = textObj.GetComponent<TextMeshProUGUI>();
        Color originalColor = uiText.color;
        Vector3 originalPos = textObj.transform.position;

        float duration = 1f;
        float elapsed = 0f;
        float dist = 10f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            uiText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            float offset = imgType == Im.NoneUp ? (elapsed / duration) * dist : -(elapsed / duration) * dist; // y方向への移動
            textObj.transform.position = new Vector3(originalPos.x, originalPos.y + offset, originalPos.z);

            yield return null;
        }

        Destroy(textObj);
    }

    private IEnumerator ShowArrowAndFadeOut(GameObject textObj, Im imgType, Ab type)
    {
        GameObject arrow;
        TextMeshProUGUI uiText = textObj.GetComponent<TextMeshProUGUI>();

        if (imgType == Im.Up)
        {
            arrow = Instantiate(upArrow, textObj.transform.position, Quaternion.identity, textObj.transform);
        }
        else
        {
            arrow = Instantiate(downArrow, textObj.transform.position, Quaternion.identity, textObj.transform);
        }

        SpriteRenderer rend = arrow.GetComponent<SpriteRenderer>();
        Vector3 originalPos = textObj.transform.position;

        float duration = 1f;
        float elapsed = 0f;
        float dist = 10f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            uiText.color = new Color(1, 1, 1, alpha);
            rend.color = new Color(1, 1, 1, alpha);

            float offset = imgType == Im.Up ? (elapsed / duration) * dist : -(elapsed / duration) * dist; // y方向への移動
            textObj.transform.position = new Vector3(originalPos.x, originalPos.y + offset, originalPos.z);

            yield return null;
        }

        Destroy(arrow);
        Destroy(textObj);
    }
}
