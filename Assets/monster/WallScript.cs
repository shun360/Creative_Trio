using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public bool active = false;
    public List<GameObject> wallList = new();
    
   
    public void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            int x = Random.Range(-106, -94);
            GameObject wallPrefab = (GameObject)Resources.Load("Wall");
            GameObject walltance = Instantiate(wallPrefab, new Vector3(x, 1, 30 + 20*i), Quaternion.identity);
            Debug.Log("Wall¶¬");
            wallList.Add(walltance);
        }

    }
    public void Delete()
    {
        for (int i = 0; i < wallList.Count; i++)
        {
            Destroy(wallList[i]);
        }

    }
}
