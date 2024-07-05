using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNo = 0;
    public bool isPlaying = false;
    
    public void PlayStart()//ボウリング開始
    {
        if (!isPlaying)
        {
            GameObject.Find("Super Pin").GetComponent<PinScript>().ArrangePins();
            isPlaying = true;
            Debug.Log("ボウリングスタート");
            FindAnyObjectByType<PinScript>().AllRemovePin();
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

