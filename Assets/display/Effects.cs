using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using StatusChangeType;

public class Effects : MonoBehaviour
{
    public GameObject sword;
    public GameObject shield;
    public GameObject soul;
    public StatusChangeText sct;
    private void Awake()
    {
        sword = (GameObject)Resources.Load("SwordEffect");
        shield = (GameObject)Resources.Load("ShieldEffect");
        soul = (GameObject)Resources.Load("SoulEffect");
        sct = FindAnyObjectByType<StatusChangeText>();
    }
    public IEnumerator ObsEffect(Vector3 pos)
    {
        GameObject effect = Instantiate(soul, pos, Quaternion.identity);
        effect.transform.localScale = new Vector3(15, 15, 1);
        effect.transform.Translate(new Vector3(0, 0, -1));
        SpriteRenderer rend = effect.GetComponent<SpriteRenderer>();
        rend.color = new(1, 1, 1, 0.9f);

        for (float i = rend.color.a; i >= 0; i -= 0.009f)
        {
            rend.color = new(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(effect);
        yield return null;
    }
    public IEnumerator BlockEffect(Vector3 pos, int block) 
    {
        yield return new WaitForSeconds(0.1f);
        sct.ShowStatusChange(pos, $"-{block}", Im.NoneDown, Ab.Block);
        GameObject effect = Instantiate(shield, pos, Quaternion.identity);
        effect.transform.localScale = new Vector3(15, 15, 1);
        effect.transform.Translate(new Vector3(0, 0, -1));
        SpriteRenderer rend = effect.GetComponent<SpriteRenderer>();
        rend.color = new(1, 1, 1, 0.7f);
        
        for (float i = rend.color.a; i >= 0; i -= 0.01f)
        {
            rend.color = new(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(effect);
        yield return null;
    }
    public IEnumerator AddBlockEffect(Vector3 pos, int amount, float scale = 15)
    {
        sct.ShowStatusChange(pos, $"+{amount}", Im.NoneUp, Ab.Block);
        GameObject effect = Instantiate(shield, pos, Quaternion.identity);
        effect.transform.localScale = new Vector3(scale, scale, 1);
        effect.transform.Translate(new Vector3(0, 0, -1));
        SpriteRenderer rend = effect.GetComponent<SpriteRenderer>();
        rend.color = new(1, 1, 1, 0.7f);
        for (float i = rend.color.a; i >= 0; i -= 0.007f)
        {
            rend.color = new(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(effect);
        yield return null;
    }

}

