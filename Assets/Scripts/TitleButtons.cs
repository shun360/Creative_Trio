using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void ReturnToTitle()
        {
        Debug.Log("Start");
            SceneManager.LoadScene("title");
        }

}
