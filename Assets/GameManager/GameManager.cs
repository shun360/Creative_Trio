using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNo;
    public bool isPlaying;
    public int turn;
    public bool throwStart;
    public bool throwEnd;
    private Display disp;
    private HeroScript hero;
    private BallScript ball;
    private PinScript pin;
    private CommandQueue queue;
    private MonsterScript mons;

    public IEnumerator GamePlay()
    {
        disp = FindObjectOfType<Display>();
        ball = FindObjectOfType<BallScript>();
        pin = FindObjectOfType<PinScript>();
        queue = FindObjectOfType<CommandQueue>();
        mons = FindObjectOfType<MonsterScript>();
        hero = FindObjectOfType<HeroScript>();
        stageNo = 1;
        isPlaying = false;
        turn = 0;
        throwStart = false;
        throwEnd = false;
        Debug.Log("GamePlay開始");
        for (int i = 2; i < ReturnMonsters.monsters.Count + 2;i++)
        {
            Debug.Log($"ステージ{i - 1}を開始します");

            yield return disp.StageStart();
            
            mons.SetMonster();
            while (stageNo < i)
            {
                yield return TurnPlay();
                if(MonsterScript.monList.Count == 0)
                {
                    StageClear();
                    
                }
            }
        }
        Debug.Log("ゲームクリア!!");
        SceneManager.LoadScene("GameClearScene");

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
        hero.BlockZero();
        mons.AllBlockZero();
        
    }
    public void StageClear()
    {
        Debug.Log("ステージクリア！");
        stageNo++;
        turn = 0;
        StartCoroutine(disp.Clear());
        hero.LevelUp();
        //FixMe：LevelUp演出
        //TODO：報酬を選ぶ
    }
    public void PlayStart()//ボウリング開始
    {
        if (!isPlaying)
        {
            throwStart = false;
            throwEnd = false;
            pin.ArrangePins();
            isPlaying = true;
            Debug.Log("ボウリングスタート");
            //FixMe：ボールを初期位置に戻すコード・移動し続ける
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
            if(pin.CheckStrike())
            {
                Debug.Log("ストライク！！ ボーナス：ファイアーボール追加");
                queue.AddCommand(ct.Fireball);
            }
            isPlaying = false;
            Debug.Log("ボウリング終了");
            pin.AllRemovePin();
            //FixMe：ボールを初期位置に戻すコード・移動し続ける
            ball.Set();
            
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

