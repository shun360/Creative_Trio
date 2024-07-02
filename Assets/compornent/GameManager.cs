using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNo = 0;
    public GameObject targetEnemy;
    public bool isPlaying = false;
    
    public void PlayStart()//�{�E�����O�J�n
    {
        GameObject.Find("Super Pin").GetComponent<PinScript>().ArrangePins();
        isPlaying = true;
        Debug.Log("�{�E�����O�X�^�[�g");
    }
    public void PlayEnd()
    {
        isPlaying = false;
        Debug.Log("�{�E�����O�I��");
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

}

