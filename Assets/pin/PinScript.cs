using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public static List<GameObject> pinList;
    private static Vector3 p = new Vector3(-100, 1, 70);//基準の位置
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
                Debug.Log("ピン生成");
                
                if(pinstance.TryGetComponent<PinClass>(out var pinCls))
                {
                    pinCls.Init(PinDeck.Deck[i]);
                }
                else
                {
                    Debug.LogError("PinPrefabにPinclassがアタッチされていません。");
                }
                pinList.Add(pinstance);
            }
        }
        else
        {
            Debug.Log("1プレイが終わっていないため、ピンを生成しませんでした。");
        }
        
    }
    public void AllRemovePin()
    {
        for(int i = 0;i < pinList.Count;i++)
        {
            Destroy(pinList[i]);
        }
        Debug.Log("すべてのピンを削除しました");
    }
    public bool CheckStrike()
    {
        if(pinList.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Awake()
    {
        pinList = new List<GameObject>();
    }
    
}
