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
    public void PlayStart()//ボウリング開始
    {
        if (!isPlaying)
        {
            GameObject.Find("Super Pin").GetComponent<PinScript>().ArrangePins();
            isPlaying = true;
            Debug.Log("ボウリングスタート");
            //ここにボールを初期位置に戻すコード
            //テスト
            FindObjectOfType<BallScript>().Set();
        }
        else
        {
            Debug.LogError("まだプレイ中です。一度プレイを終わらせてください。");
        }

    }
    public void PlayEnd()
    {
        if (isPlaying) 
        {
            isPlaying = false;
            Debug.Log("ボウリング終了");

            FindAnyObjectByType<PinScript>().AllRemovePin();
            //ここにボールを初期位置に戻すコード
            //テスト
            FindObjectOfType<BallScript>().Set();
            //FindObjectOfType<CommandQueue>().AllCommandsExe();
        }
        else
        {
            Debug.LogError("プレイ中ではありません。");
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

