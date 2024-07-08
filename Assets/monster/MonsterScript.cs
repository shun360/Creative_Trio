using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class MonsterScript : MonoBehaviour
{
    public static List<GameObject> monInstances;
    private static Vector3 p = new(65, 75, 0);
    private static Vector3[] positions =
    {
        p,
        new(p.x + 20, p.y - 15, p.z),
        new(p.x - 25, p.y + 10, p.z)
    };
    public void ArrangeMonsters(List<mt> mts)
    {
        if (!GameManager.Instance.isPlaying)
        {
            for (int i = 0; i < PinDeck.Deck.Count && i < positions.Length; i++)
            {
                GameObject monPrefab = (GameObject)Resources.Load("Monster");
                GameObject monstance = Instantiate(monPrefab, positions[i], Quaternion.identity);
                Debug.Log("�����X�^�[����");
                MonsterClass monCls = new MonsterClass();
                switch (mts[i]){
                    case mt.Slime:
                        monCls = new SlimeClass();
                        break;
                    case mt.Bat:
                        monCls = new BatClass();
                        break;
                    case mt.Mummy:
                        monCls = new MummyClass();
                        break;
                    case mt.Gargoyle:
                        monCls = new GargoyleClass();
                        break;
                    
                }
                if (monCls != null)
                {
                    monCls.Init();
                }
                else
                {
                    Debug.LogError("MonsterPrefab���A�^�b�`����Ă��܂���B");
                }
                monInstances.Add(monstance);
            }
        }
        else
        {
            Debug.Log("�{�E�����O���I����Ă��Ȃ����߁A�����X�^�[�𐶐����܂���ł����B");
        }
    }

    public IEnumerator MonsterActs()
    {
        Debug.Log("�����X�^�[�s���J�n");
        yield return new WaitForSeconds(1);//FixMe�F�����X�^�[�s�����s�A���������X�^�[�����Ȃ����yield return null;
        Debug.Log("�����X�^�[�s���I��");
    }

    private void Awake()
    {
        monInstances = new List<GameObject> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
