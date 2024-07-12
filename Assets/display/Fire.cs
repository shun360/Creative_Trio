using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private SpriteRenderer rend;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = new(1, 1, 1, 0);
    }
    public IEnumerator ShowFire()
    {
        rend.color = new(1, 1, 1, 1);
        for (float i = rend.color.a;i >= 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            rend.color = new(1, 1, 1, i);
        }
        rend.color = new(1, 1, 1, 0);
    }
}
