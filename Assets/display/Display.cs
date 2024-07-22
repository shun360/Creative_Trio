using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using senceName;

public class Display : MonoBehaviour
{
    public GameObject prefab;

    private void Awake()
    {
        prefab = (GameObject)Resources.Load("Around");
        if (prefab == null)
        {
            Debug.LogError("Prefab 'Around' could not be loaded. Make sure the prefab exists in the Resources folder.");
        }
        else
        {
            Debug.Log("Prefab 'Around' successfully loaded.");
        }
    }
    private void Start()
    {
        
    }
    public IEnumerator StageStart()
    {
        Debug.Log("StageStart method called.");
        GameObject field = Instantiate(prefab, gameObject.transform);
        if (field == null)
        {
            Debug.LogError("Field prefab could not be instantiated.");
            yield break;
        }
        field.transform.localPosition = Vector3.zero;
        Image img = field.GetComponent<Image>();
        TextMeshProUGUI text = field.GetComponentInChildren<TextMeshProUGUI>();
        text.SetText($"STAGE {GameManager.Instance.stageNo}");
        img.color = new Color(0.75f, 0.75f, 0.75f, 0.6f);
        text.color = new Color(1, 1, 1, 1);
        
        yield return new WaitForSeconds(1f);
        for (float i = text.color.a; i >= 0; i -= 0.02f)
        {
            if (field == null || img == null || text == null)
            {
                Debug.LogWarning("Field or its components were destroyed during coroutine execution.");
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
            img.color = new Color(0.75f, 0.75f, 0.75f, i * 0.6f);
            text.color = new Color(1, 1, 1, i);
        }
        Destroy(field);
    }

    public IEnumerator Clear()
    {
        GameObject field = Instantiate(prefab, gameObject.transform);
        field.transform.localPosition = Vector3.zero;
        Image img = field.GetComponent<Image>();
        TextMeshProUGUI text = field.GetComponentInChildren<TextMeshProUGUI>();
        text.SetText($"STAGE {GameManager.Instance.stageNo} CLEAR!");
        img.color = new Color(0.75f, 0.75f, 0.75f, 0.6f);
        text.color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(1f);
        for (float i = text.color.a; i >= 0; i -= 0.02f)
        {
            yield return new WaitForSeconds(0.01f);
            img.color = new Color(0.75f, 0.75f, 0.75f, i * 0.6f);
            text.color = new Color(1, 1, 1, i);
        }
        Destroy(field);
    }
    public IEnumerator Turn()
    {
        if(GameManager.Instance.sence == Sence.Sample)
        {
            GameObject field = Instantiate(prefab, gameObject.transform);
            if (field == null)
            {
                Debug.LogError("Field prefab could not be instantiated.");
                yield break;
            }
            field.transform.localPosition = Vector3.zero;
            Image img = field.GetComponent<Image>();
            TextMeshProUGUI text = field.GetComponentInChildren<TextMeshProUGUI>();
            text.SetText($"TURN {GameManager.Instance.turn}");
            img.color = new Color(0.75f, 0.75f, 0.75f, 0.6f);
            text.color = new Color(1, 1, 1, 1);

            yield return new WaitForSeconds(1f);
            for (float i = text.color.a; i >= 0; i -= 0.02f)
            {
                if (field == null || img == null || text == null)
                {
                    Debug.LogWarning("Field or its components were destroyed during coroutine execution.");
                    yield break;
                }
                yield return new WaitForSeconds(0.01f);
                img.color = new Color(0.75f, 0.75f, 0.75f, i * 0.6f);
                text.color = new Color(1, 1, 1, i);
            }
            Destroy(field);
        }
        
    }
}
