using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public GameObject pinPrefab;
    public static List<GameObject> pinList;
    public static List<GameObject> pinYetSentList;
    private static Vector3 p = new Vector3(-100, 1, 70);//��̈ʒu
    private static float m = 2f;
    private static readonly Vector3[] positions =
    {
        p,
        new Vector3(p.x - m, p.y, p.z + 1.75f * m),
        new Vector3(p.x + m, p.y, p.z + 1.75f * m),
        new Vector3(p.x - 2 * m, p.y, p.z + 3.5f * m),
        new Vector3(p.x, p.y, p.z + 3.5f * m),
        new Vector3(p.x + 2 * m, p.y, p.z + 3.5f * m),
        new Vector3(p.x - 3 * m, p.y, p.z + 5.25f * m),
        new Vector3(p.x - m, p.y, p.z + 5.25f * m),
        new Vector3(p.x + m, p.y, p.z + 5.25f * m),
        new Vector3(p.x + 3 * m, p.y, p.z + 5.25f * m),
    };
    
    public void ArrangePins()
    {
        if (!GameManager.Instance.isPlaying)
        {
            for (int i = 0; i < PinDeck.Deck.Count && i < positions.Length; i++)
            {
                GameObject pinstance = Instantiate(pinPrefab, positions[i], Quaternion.identity);
                
                
                if(pinstance.TryGetComponent<PinClass>(out var pinCls))
                {
                    pinCls.Init(PinDeck.Deck[i]);
                }
                else
                {
                    Debug.LogError("PinPrefab��Pinclass���A�^�b�`����Ă��܂���B");
                }
                pinList.Add(pinstance);
                pinYetSentList.Add(pinstance);
            }
        }
        else
        {
            Debug.Log("1�v���C���I����Ă��Ȃ����߁A�s���𐶐����܂���ł����B");
        }
        
    }
    public void AllRemovePin()
    {
        for(int i = 0;i < pinList.Count;i++)
        {
            Destroy(pinList[i]);
        }
        pinYetSentList.Clear();     
        
        Debug.Log("���ׂẴs�����폜���܂���");
    }
    public bool CheckStrike()
    {
        if(pinYetSentList.Count == 0)
        {
            return true;
        }
        else
        {
            Debug.Log($"�c���Ă���s����{pinYetSentList.Count}�{�ł�");
            return false;
        }
    }

    private void Awake()
    {
        pinList = new List<GameObject>();
        pinYetSentList = new List<GameObject>();
        pinPrefab = (GameObject)Resources.Load("Pin");
    }
    
}
