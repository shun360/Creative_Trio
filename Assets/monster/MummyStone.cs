using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MummyStone : MonoBehaviour
{
    public bool active = false;
    public List<GameObject> stoneList = new();
    private static Vector3 p = new(-105, 1, 40);
    private static float x = 2.5f;
    private static float z = 10;
    private Vector3[,] pos = new Vector3[3, 5];
    

    private void Awake()
    {
        for(int i = 0; i < pos.GetLength(0); i++)
        {
            for (int j = 0; j < pos.GetLength(1); j++)
            {
                pos[i, j] = new Vector3(p.x + x * j, p.y, p.z + z * i);
            }
        }
    }
    public void Spawn()
    {
        List<int> indexList = new();
        for(int i =0; i < pos.GetLength(1); i++)
        {
            indexList.Add(i);
        }
        for(int i = 0; i < pos.GetLength(0); i++)
        {
            int c = indexList[Random.Range(0, indexList.Count)];
            GameObject StonePrefab = (GameObject)Resources.Load("Stone");
            GameObject stonetance = Instantiate(StonePrefab, pos[i, c], Quaternion.identity);
            indexList.Remove(c);
            Debug.Log("Stone¶¬");
            stoneList.Add(stonetance);
               
        }
        
    }
    public void Delete()
    {
        for(int i = 0;i < stoneList.Count; i++)
        {
            Destroy(stoneList[i]);
        }
        
    }
}
