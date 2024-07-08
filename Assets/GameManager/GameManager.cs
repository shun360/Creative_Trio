using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNo = 0;
    public bool isPlaying = false;
    public int turn = 0;
    private Display disp = FindObjectOfType<Display>();
    public void GamePlay()
    {

    }
    
    IEnumerator TurnPlay()
    {
        turn++;
        yield return disp.Turn();
        
    }
    public void StageClear()
    {
        stageNo++;
        turn = 0;
    }
    public void PlayStart()//�{�E�����O�J�n
    {
        if (!isPlaying)
        {
            GameObject.Find("Super Pin").GetComponent<PinScript>().ArrangePins();
            isPlaying = true;
            Debug.Log("�{�E�����O�X�^�[�g");
            //�����Ƀ{�[���������ʒu�ɖ߂��R�[�h
            //�e�X�g
            FindObjectOfType<BallScript>().Set();
        }
        else
        {
            Debug.LogError("�܂��v���C���ł��B��x�v���C���I��点�Ă��������B");
        }

    }
    public void PlayEnd()
    {
        if (isPlaying) 
        {
            isPlaying = false;
            Debug.Log("�{�E�����O�I��");

            FindAnyObjectByType<PinScript>().AllRemovePin();
            //�����Ƀ{�[���������ʒu�ɖ߂��R�[�h
            //�e�X�g
            FindObjectOfType<BallScript>().Set();
            //FindObjectOfType<CommandQueue>().AllCommandsExe();
        }
        else
        {
            Debug.LogError("�v���C���ł͂���܂���B");
        }

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

