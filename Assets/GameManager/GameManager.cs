using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;
using UnityEngine.SceneManagement;
using senceName;

namespace senceName
{
    public enum Sence
    {
        Title,
        Sample,
        GameOver,
        GameClear
    }
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Coroutine gameCoroutine;
    public int stageNo;
    public bool isPlaying;
    public int turn;
    public int sumTurn;
    public bool throwStart;
    public bool throwEnd;
    public int restPin;
    public bool onlyOne;
    public bool metal;
    public Sence sence;
    public Display disp;
    private HeroScript hero;
    private BallScript ball;
    private PinScript pin;
    private CommandQueue queue;
    private MonsterScript mons;
    private MummyStone stone;
    private WallScript wall;
    private RewardScript reward;
    private StrikeDisp strike;

    public void GameReset()
    {
        stageNo = 1;
        isPlaying = false;
        turn = 0;
        sumTurn = 0;
        throwStart = false;
        throwEnd = false;
        restPin = -1;
        onlyOne = false;
        metal = false;
    }
    public void StartGamePlay()
    {
        if(gameCoroutine != null)
        {
            StopCoroutine(gameCoroutine);
        }
        gameCoroutine = StartCoroutine(GamePlay());
    }
    public IEnumerator GamePlay()
    {
        
        GameReset();
        yield return new WaitForSeconds(0.1f);
        ball = FindObjectOfType<BallScript>();
        pin = FindObjectOfType<PinScript>();
        queue = FindObjectOfType<CommandQueue>();
        mons = FindObjectOfType<MonsterScript>();
        hero = FindObjectOfType<HeroScript>();
        stone = FindObjectOfType<MummyStone>();
        wall = FindObjectOfType<WallScript>();
        reward = FindObjectOfType<RewardScript>();
        disp = FindObjectOfType<Display>();
        strike = FindObjectOfType<StrikeDisp>();
        if (disp == null)
        {
            Debug.LogError("Display オブジェクトが見つかりませんでした。");
            yield break;
        }
        else
        {
            Debug.Log("Display オブジェクトが見つかりました: " + disp.gameObject.name);
        }
        
        Debug.Log("GamePlay開始");
        
        for (int i = 2; i < ReturnMonsters.monsters.Count + 2;i++)
        {
            Debug.Log($"ステージ{i - 1}を開始します");

            yield return disp.StageStart();
            
            mons.SetMonster();
            while (stageNo < i)
            {
                yield return TurnPlay();
                if(MonsterScript.monList.Count == 0 && hero.nowHP > 0)
                {
                    yield return StageClear();
                }
            }
        }
        yield return new WaitForSeconds(2);
        Debug.Log("ゲームクリア!!");
        SceneManager.LoadScene("GameClearScene");
        sence = Sence.GameClear;
        Debug.Log("GamePlay()終了");
    }
    IEnumerator TurnPlay()
    {
        turn++;
        sumTurn++;
        PinDeck.Shuffle();
        yield return disp.Turn();//この行でTurn()呼び出し
        yield return PlayStart();
        yield return new WaitUntil(() => throwEnd);
        yield return PlayEnd();
        yield return queue.AllCommandsExe();
        mons.AllBlockZero();
        yield return mons.MonstersAct();
        hero.BlockZero();
        
        
    }
    public IEnumerator StageClear()
    {
        stone.active = false;
        wall.active = false;
        turn = 0;
        if (stageNo < 5)
        {
            Debug.Log("ステージクリア！");
            yield return disp.Clear();
            yield return hero.LevelUp();
            hero.StatusReset();
            yield return reward.RewardSelect();
        }
        stageNo++;

    }
    public IEnumerator PlayStart()//ボウリング開始
    {
        
        throwStart = false;
        throwEnd = false;
        if (metal && hero != null)
        {
            StartCoroutine(hero.AddBlock(now: false));
        }
        if(hero.nowHP > 0)
        {
            pin.ArrangePins();
        }
        isPlaying = true;
        if (stone.active)
        {
            stone.Spawn();
        }
        if (wall.active)
        {
            wall.Spawn();
        }
        //Debug.Log("ボウリングスタート");
        ball.Set();
        mons.ActScheduleDisp();
        yield return new WaitForSeconds(1);
    }
    public IEnumerator PlayEnd()
    {

        restPin = PinScript.pinYetSentList.Count;
        if (stone.active)
        {
            stone.Delete();
        }
        if (wall.active)
        {
            wall.Delete();
        }
        isPlaying = false;
        //Debug.Log("ボウリング終了");
        pin.AllRemovePin();
        ball.Set();
        yield return new WaitForSeconds(1);

    }
    public void StrikeEffect()
    {
        if (!onlyOne)
        {
            Debug.Log("ストライク！！ ボーナス：ファイアーボール追加");
            queue.AddCommand(Ct.Fire);
            StartCoroutine(strike.Show());
        }


    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            sence = Sence.Title;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartButton()
    {
        Debug.Log("StartButton()");
        SceneManager.LoadScene("SampleScene");
        sence = Sence.Sample;
        StartGamePlay();
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        mons.DeleteMonsters();
        sence = Sence.GameOver;
    }

}

