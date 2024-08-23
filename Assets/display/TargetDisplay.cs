using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDisplay : MonoBehaviour
{
    private HeroScript hero;
    private SpriteRenderer rend;
    private Coroutine dispCoroutine;
    /*private static Vector3 p = new(65, 75, -1);
    private static Vector3[] positions =
    {
        p,
        new(p.x + 20, p.y - 15, p.z),
        new(p.x - 25, p.y + 10, p.z)
    };*/
    public void DispTarget()
    {
        if(dispCoroutine != null)
        {
            StopCoroutine(dispCoroutine);
        }
        dispCoroutine = StartCoroutine(Disp());
    }
    public IEnumerator Disp()
    {
        
        if (MonsterScript.monList.Count > 0)
        {
            transform.position = MonsterScript.monList[hero.targetNumber].transform.position;
            transform.Translate(new Vector3(0, 0, -1));
            rend.color = new(1, 1, 1, 1);
            yield return new WaitForSeconds(0.5f);
            for (float i = 1; i >= 0; i -= 0.01f)
            {
                if(MonsterScript.monList.Count == 0)
                {
                    rend.color = new(1, 1, 1, 0);
                    break;
                }
                yield return new WaitForSeconds(0.01f);
                rend.color = new(1, 1, 1, i);
            }
        }
        else
        {
            Debug.Log("モンスターがいないのでターゲット表示できませんでした");
        }
        
    }

    void Awake()
    {
        hero = FindObjectOfType<HeroScript>();
        rend = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
