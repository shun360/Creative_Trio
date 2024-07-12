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
    public int sumTurn;
    public bool throwStart;
    public bool throwEnd;
    public int restPin;
    public bool onlyOne;
    public bool metal;
    private Display disp;
    private HeroScript hero;
    private BallScript ball;
    private PinScript pin;
    private CommandQueue queue;
    private MonsterScript mons;
    private MummyStone stone;
    private WallScript wall;
    private RewardScript reward;

    public IEnumerator GamePlay()
    {
        disp = FindObjectOfType<Display>();
        ball = FindObjectOfType<BallScript>();
        pin = FindObjectOfType<PinScript>();
        queue = FindObjectOfType<CommandQueue>();
        mons = FindObjectOfType<MonsterScript>();
        hero = FindObjectOfType<HeroScript>();
        stone = FindObjectOfType<MummyStone>();
        wall = FindObjectOfType<WallScript>();
        reward = FindObjectOfType<RewardScript>();
        
        stageNo = 1;
        isPlaying = false;
        turn = 0;
        sumTurn = 0;
        throwStart = false;
        throwEnd = false;
        restPin = -1;
        onlyOne = false;
        metal = false;
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
                    yield return StageClear();
                    
                }
            }
        }
        yield return new WaitForSeconds(3);
        Debug.Log("ゲームクリア!!");
        SceneManager.LoadScene("GameClearScene");

    }
    IEnumerator TurnPlay()
    {
        turn++;
        sumTurn++;
        PinDeck.Shuffle();
        yield return disp.Turn();
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
        Debug.Log("ステージクリア！");
        stone.active = false;
        wall.active = false;
        stageNo++;
        turn = 0;
        yield return disp.Clear();
        yield return hero.LevelUp();
        hero.StatusReset();
        //FixMe：LevelUp演出
        yield return reward.RewardSelect();
    }
    public IEnumerator PlayStart()//ボウリング開始
    {
        
        throwStart = false;
        throwEnd = false;
        if (metal)
        {
            StartCoroutine(hero.AddBlock(now: false));
        }
        pin.ArrangePins();
        isPlaying = true;
        if (stone.active)
        {
            stone.Spawn();
        }
        if (wall.active)
        {
            wall.Spawn();
        }
        Debug.Log("ボウリングスタート");
        ball.Set();
        yield return new WaitForSeconds(1);
        

    }
    public IEnumerator PlayEnd()
    {
        restPin = pin.RestPins();
        if(restPin == 0 && !onlyOne)
        {
            Debug.Log("ストライク！！ ボーナス：ファイアーボール追加");
            queue.AddCommand(Ct.Fireball);
        }
        if (stone.active)
        {
            stone.Delete();
        }
        if (wall.active)
        {
            wall.Delete();
        }
        isPlaying = false;
        Debug.Log("ボウリング終了");
        pin.AllRemovePin();
        ball.Set();
        yield return new WaitForSeconds(1);

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
        StartCoroutine(GamePlay());
    }
    void Update()
    {
        
    }

}

