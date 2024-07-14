using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found on this GameObject.");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager instance is null.");
            return;
        }

        try
        {
            button.onClick.AddListener(GameManager.Instance.StartButton);
        }
        catch (ArgumentException e)
        {
            Debug.LogError($"Error adding listener to button: {e.Message}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
