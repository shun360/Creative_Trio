using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private static List<GameObject> pinInstances;
    private static Vector3 p = new Vector3(-100, 1, 70);//��̈ʒu
    
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
            for (int i = 0; i < HeroPinDeck.PinDeck.Count && i < positions.Length; i++)
            {
                GameObject pinPrefab = (GameObject)Resources.Load("Pin");
                GameObject pinstance = Instantiate(pinPrefab, positions[i], Quaternion.identity);
                Debug.Log("�s������");
                PinClass pinCls = pinstance.GetComponent<PinClass>();
                if(pinCls != null)
                {
                    pinCls.Init(HeroPinDeck.PinDeck[i]);
                }
                else
                {
                    Debug.LogError("PinPrefab��Pinclass���A�^�b�`����Ă��܂���B");
                }
                pinInstances.Add(pinstance);
            }
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
    
}
