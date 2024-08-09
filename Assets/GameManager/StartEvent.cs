using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour
{
    public void StartClick()
    {
        GameManager.Instance.StartButton();
    }
}
