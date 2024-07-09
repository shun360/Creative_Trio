using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDisplay : MonoBehaviour
{
    private HeroScript hero;
    private SpriteRenderer rend;
    private Coroutine dispCoroutine;
    private static Vector3 p = new(65, 75, -1);
    private static Vector3[] positions =
    {
        p,
        new(p.x + 20, p.y - 15, p.z),
        new(p.x - 25, p.y + 10, p.z)
    };
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
            Debug.Log("�^�[�Q�b�g�摜�\��");
            transform.position = positions[hero.targetNumber];
            rend.color = new(1, 1, 1, 1);
            yield return new WaitForSeconds(0.5f);
            for (float i = 1; i >= 0; i -= 0.01f)
            {
                Debug.Log("�^�[�Q�b�g�摜�����񂾂񓧖��ɂ���");
                yield return new WaitForSeconds(0.01f);
                rend.color = new(1, 1, 1, i);
            }
        }
        else
        {
            Debug.Log("�����X�^�[�����Ȃ��̂Ń^�[�Q�b�g�\���ł��܂���ł���");
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