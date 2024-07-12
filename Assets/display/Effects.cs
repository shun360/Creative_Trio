using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EffectColor;

public class Effects : MonoBehaviour
{
    public GameObject sword;
    public GameObject shield;

    private void Awake()
    {
        sword = (GameObject)Resources.Load("SwordEffect");
        shield = (GameObject)Resources.Load("ShieldEffect");
    }
    public IEnumerator BuffATKEffect(Vector3 pos)
    {
        //FixMe
        yield return null;
    }
    public IEnumerator BuffDEFEffect(Vector3 pos) 
    { 
        //FixMe
        yield return null;
    
    }
    public IEnumerator BlockEffect(Vector3 pos) 
    {
        
        yield return null;
    }
    public IEnumerator AddBlockEffect(Vector3 pos, int amount, float scale = 15)
    {
        GameObject effect = Instantiate(shield, pos, Quaternion.identity);
        effect.transform.localScale = new Vector3(scale, scale, 1);
        effect.transform.Translate(new Vector3(0, 0, -1));
        SpriteRenderer rend = effect.GetComponent<SpriteRenderer>();
        rend.color = new(1, 1, 1, 0.7f);
        for (float i = rend.color.a; i >= 0; i -= 0.007f)
        {
            effect.transform.Translate(new Vector3(0, 0, 0.01f));
            rend.color = new(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(effect);
        yield return null;
    }

}
namespace EffectColor
{
    public enum Ec
    {
        Blue,
        Orange
    }
}
