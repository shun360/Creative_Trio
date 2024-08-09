using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtons : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {
        
    }
    
    public void ReturnToTitle()
        {
        GameManager.Instance.sence = senceName.Sence.Title;
        SceneManager.LoadScene("title");
        }
    public void Restart()
    {
        GameManager.Instance.StartButton();
    }

}
