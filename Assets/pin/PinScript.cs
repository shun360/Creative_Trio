using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private static List<GameObject> pinInstances;
    private static Vector3 p = new Vector3(-100, 1, 70);//基準の位置
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
                Debug.Log("ピン生成");
                pinInstances.Add(pinstance);
                switch (HeroPinDeck.PinDeck[i + deckcycle * 10])
                {
                    case CommandType.Attack:

                        //Attackピンの特性付与
                        break;
                    case CommandType.Block:
                        //Blockピンの特性付与
                        break;
                    case CommandType.Fireboll:
                        //Firebollピンの特性付与
                        break;
                }
            }
            //デッキ2周目以降の処理の途中
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
