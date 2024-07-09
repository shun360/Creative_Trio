using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        SceneManager.LoadScene("title");
    }

}