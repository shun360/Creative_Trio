using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public class GameOver : MonoBehaviour
    {
        public void ReturnToTitle()
        {
            SceneManager.LoadScene("title");
        }
    }
}
