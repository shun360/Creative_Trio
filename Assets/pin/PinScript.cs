using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private static List<GameObject> pinInstances;
    private static Vector3 p = new Vector3(-100, 1, 70);//基準の位置
    private static float m = 1.5f;
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
            for (int i = 0; i < HeroPinDeck.PinDeck.Count && i < positions.Length; i++)
            {
                GameObject pinPrefab = (GameObject)Resources.Load("Pin");
                GameObject pinstance = Instantiate(pinPrefab, positions[i], Quaternion.identity);
                Debug.Log("ピン生成");
                PinClass pinCls = pinstance.GetComponent<PinClass>();
                if(pinCls != null)
                {
                    pinCls.Init(HeroPinDeck.PinDeck[i]);
                }
                else
                {
                    Debug.LogError("PinPrefabにPinclassがアタッチされていません。");
                }
                pinInstances.Add(pinstance);
            }
        }
        else
        {
            Debug.Log("1プレイが終わっていないため、ピンを生成しませんでした。");
        }
        
    }
    private void Awake()
    {
        pinInstances = new List<GameObject>();
    }
    
}
