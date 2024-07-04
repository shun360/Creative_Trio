using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YanoGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void YanoStart()
    {
        
    }

    // Update is called once per frame
    void YanoUpdate()
    {
        
    }

    public void StartButton()
    {
        Debug.Log("YanoStart");
        SceneManager.LoadScene("SampleScene");
    }
}
