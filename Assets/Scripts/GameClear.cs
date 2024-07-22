using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using senceName;

public class GameClear : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ClearReturnToTitle()
    {
        Debug.Log("Start");
        GameManager.Instance.sence = Sence.Title;
        SceneManager.LoadScene("title");
        
    }

}