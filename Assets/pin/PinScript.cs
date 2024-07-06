using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public static List<GameObject> pinInstances;
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
                GameObject pinPrefab = (GameObject)Resources.Load("Pin");
                GameObject pinstance = Instantiate(pinPrefab, positions[i], Quaternion.identity);
                Debug.Log("�s������");
                PinClass pinCls = pinstance.GetComponent<PinClass>();
                if(pinCls != null)
                {
                    pinCls.Init(PinDeck.Deck[i]);
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
    public void AllRemovePin()
    {
        for(int i = 0;i < pinInstances.Count;i++)
        {
            Destroy(pinInstances[i]);
        }
        Debug.Log("���ׂẴs�����폜���܂���");
    }

    private void Awake()
    {
        pinInstances = new List<GameObject>();
    }
    
}
