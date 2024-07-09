using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class MonsterScript : MonoBehaviour
{
    public static List<GameObject> monList;
    private static Vector3 p = new(65, 75, 0);
    private static Vector3[] positions =
    {
        p,
        new(p.x + 20, p.y - 15, p.z),
        new(p.x - 25, p.y + 10, p.z)
    };
    public void ArrangeMonsters(List<mt> mts)
    {
        
        for (int i = 0; i < mts.Count; i++)
        {
            GameObject monPrefab = (GameObject)Resources.Load("MonsterPrefab");//TODO:Prefab�̐ݒ������
            GameObject monstance = Instantiate(monPrefab, positions[i], Quaternion.identity);
            Debug.Log("�����X�^�[����");
            
            switch (mts[i]){
                case mt.Slime:
                    monstance.AddComponent<SlimeClass>().Init();
                    break;
                case mt.Bat:
                    monstance.AddComponent<BatClass>().Init();
                    break;
                case mt.Mummy:
                    monstance.AddComponent<MummyClass>().Init();
                    break;
                case mt.Gargoyle:
                    monstance.AddComponent<GargoyleClass>().Init();
                    break;
                default:
                    monstance.AddComponent<MonsterClass>().Init();
                    break;
                    
            }
            monList.Add(monstance);
        }
        
        
    }
    public void SetMonster()
    {
        ArrangeMonsters(FindObjectOfType<ReturnMonsters>().StageMonsters(GameManager.Instance.stageNo));
    }

    public IEnumerator MonsterActs()
    {
        Debug.Log("�����X�^�[�s���J�n");
        yield return new WaitForSeconds(1);//FixMe�F�����X�^�[�s�����s�A���������X�^�[�����Ȃ����yield return null;
        Debug.Log("�����X�^�[�s���I��");
    }
    public void DeleteMonsters()
    {
        for (int i = 0; i < monList.Count; i++)
        {
            StartCoroutine(monList[i].GetComponent<MonsterClass>().YieldDead());
        }
    }
    private void Awake()
    {
        monList = new List<GameObject> ();
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
