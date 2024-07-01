using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private static List<GameObject> pinInstances;
    private static Vector3 p = new Vector3(-100, 1, 70);//��̈ʒu
    private int deckcycle = 0;
    private static readonly Vector3[] positions =
    {
        p,
        new Vector3(p.x - 1, p.y, p.z + 1.75f),
        new Vector3(p.x + 1, p.y, p.z + 1.75f),
        new Vector3(p.x - 2, p.y, p.z + 3.5f),
        new Vector3(p.x + 0, p.y, p.z + 3.5f),
        new Vector3(p.x + 2, p.y, p.z + 3.5f),
        new Vector3(p.x - 3, p.y, p.z + 5.25f),
        new Vector3(p.x - 1, p.y, p.z + 5.25f),
        new Vector3(p.x + 1, p.y, p.z + 5.25f),
        new Vector3(p.x + 3, p.y, p.z + 5.25f),
    };
    
    public void ArrangePins()
    {
        if (!GameManager.Instance.isPlaying)
        {

            for (int i = 0 ;deckcycle * 10 + i < HeroPinDeck.PinDeck.Count && i < positions.Length; i++)
            {
                GameObject pinPrefab = (GameObject)Resources.Load("Pin");
                GameObject pinstance = Instantiate(pinPrefab, positions[i], Quaternion.identity);
                Debug.Log("�s������");
                pinInstances.Add(pinstance);
                switch (HeroPinDeck.PinDeck[i + deckcycle * 10])
                {
                    case CommandType.Attack:

                        //Attack�s���̓����t�^
                        break;
                    case CommandType.Block:
                        //Block�s���̓����t�^
                        break;
                    case CommandType.Fireboll:
                        //Fireboll�s���̓����t�^
                        break;
                }
            }
            //�f�b�L2���ڈȍ~�̏����̓r��
        }
        else
        {
            Debug.Log("1�v���C���I����Ă��Ȃ����߁A�s���𐶐����܂���ł����B");
        }
        
    }
    private void Awake()
    {
        pinInstances = new List<GameObject>();
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
