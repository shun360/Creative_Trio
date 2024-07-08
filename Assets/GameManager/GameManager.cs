using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNo = 1;
    public bool isPlaying = false;
    public int turn = 0;
    public bool throwEnd = false;
    private Display disp;
    private BallScript ball;
    private PinScript pin;
    private CommandQueue queue;
    private MonsterScript mons;
    public void GamePlay()
    {
        disp = FindObjectOfType<Display>();
        ball = FindObjectOfType<BallScript>();
        pin = FindObjectOfType<PinScript>();
        queue = FindObjectOfType<CommandQueue>();
        mons = FindObjectOfType<MonsterScript>();
        for (int i = 2; i < ReturnMonsters.monsters.Count + 2;i++)
        {
            StartCoroutine(disp.StageStart());
            //TODO：stageNoのモンスターを出す
            while (stageNo < i)
            {
                StartCoroutine(TurnPlay());
                if(MonsterScript.monInstances.Count == 0)
                {
                    StageClear();
                }
            }
        }
    }
    IEnumerator TurnPlay()
    {
        turn++;
        yield return disp.Turn();
        PlayStart();
        yield return new WaitUntil(() => throwEnd);
        PlayEnd();
        yield return queue.AllCommandsExe();
        yield return mons.MonsterActs();

        
    }
    public void StageClear()
    {
        stageNo++;
        turn = 0;
        StartCoroutine(disp.Clear());
        //TODO：LevelUp!攻撃力+1、防御力+1する
        //TODO：報酬を選ぶ
    }
    public void PlayStart()//ボウリング開始
    {
        if (!isPlaying)
        {
            throwEnd = false;
            pin.ArrangePins();
            isPlaying = true;
            Debug.Log("ボウリングスタート");
            //FixMe：ボールを初期位置に戻すコード
            ball.Set();
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
            FindObjectOfType<PinScript>().AllRemovePin();
            //FixMe：ボールを初期位置に戻すコード
            FindObjectOfType<BallScript>().Set();
            
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

