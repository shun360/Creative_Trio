using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class QueueDisplay : MonoBehaviour
{
    private Vector3 pos = new Vector3(-354, -10, 0);
    private float dist = 7.5f;
    private List<Coroutine> coroutineList = new List<Coroutine>(); 
    public List<GameObject> iconList;
    public void AddIcon(Ct ct)
    {
        GameObject prefab = (GameObject)Resources.Load("QueueIcon");
        GameObject icon = Instantiate(prefab, this.transform.position, Quaternion.identity);
        icon.GetComponent<QueueIconClass>().IconSet(ct);
        iconList.Add(icon);
        Vector3 p = pos;
        p.x -= dist * (iconList.Count - 1);
        icon.transform.position = p;
    }
    public void Dequeue()
    {
        GameObject icon = iconList[0];
        iconList.RemoveAt(0);
        Destroy(icon);
        DownIcons();
    }
    public void DownIcons()
    {
        for (int i = 0; i < iconList.Count; i++)
        {
            Coroutine cr = StartCoroutine(iconList[i].GetComponent<QueueIconClass>().Right(dist));
            coroutineList.Add(cr);
        }
    }
    public void DeleteIcons()
    {
        for(int i = 0; i < coroutineList.Count; i++)
        {
            StopCoroutine(coroutineList[i]);
        }
        coroutineList.Clear();
        for(int i = iconList.Count - 1; i >= 0; i--)
        {
            Destroy(iconList[i]);
        }
        Debug.Log(iconList.Count);
        iconList.Clear();
    }
    
}
