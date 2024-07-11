using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Result;

public class RewardScript : MonoBehaviour
{
    public GameObject buttonPrefab;
    public List<GameObject> buttunList = new List<GameObject>();
    public List<Re> allRewards;
    public List<Re> yetRewards;
    public List<Re> selectedRewards;
    public Re select;
    public bool click = false;
    private void Awake()
    {
        buttonPrefab = (GameObject)Resources.Load("Button");
    }
    private void Start()
    {

        allRewards = new List<Re>((Re[])System.Enum.GetValues(typeof(Re)));
        yetRewards = new List<Re>((Re[])System.Enum.GetValues(typeof(Re)));

    }
    public List<Re> RandomSelectThree()
    {
        List<Re> temp = new List<Re>();
        int index =0;
        for (int i = 0;i < 3; i++)
        {
            index = Random.Range(0, yetRewards.Count);
            Re rew = yetRewards[index];
            temp.Add(rew);
            yetRewards.Remove(rew);
        }

        return temp;
    }
    public IEnumerator DispButtun(List<Re> rewards)
    {
        foreach(Re rew in rewards)
        {
            //GameObject button = Instantiate(buttonPrefab,);
        }
        
        yield return new WaitUntil(() => click);

    }
}
