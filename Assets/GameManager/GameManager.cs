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
    private MummyStone stone;
    private WallScript wall;

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
        stageNo = 1;
        isPlaying = false;
        turn = 0;
        throwStart = false;
        throwEnd = false;
        Debug.Log("GamePlay�J�n");
        for (int i = 2; i < ReturnMonsters.monsters.Count + 2;i++)
        {
            Debug.Log($"�X�e�[�W{i - 1}���J�n���܂�");

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
        Debug.Log("�Q�[���N���A!!");
        SceneManager.LoadScene("GameClearScene");

    }
    IEnumerator TurnPlay()
    {
        turn++;
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
        Debug.Log("�X�e�[�W�N���A�I");
        stone.active = false;
        wall.active = false;
        stageNo++;
        turn = 0;
        yield return disp.Clear();
        yield return hero.LevelUp();
        hero.StatusReset();
        //FixMe�FLevelUp���o
        //TODO�F��V��I��
    }
    public IEnumerator PlayStart()//�{�E�����O�J�n
    {
        
        throwStart = false;
        throwEnd = false;
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
        Debug.Log("�{�E�����O�X�^�[�g");
        //FixMe�F�{�[���������ʒu�ɖ߂��R�[�h�E�ړ���������
        ball.Set();
        yield return new WaitForSeconds(1);
        

    }
    public IEnumerator PlayEnd()
    {
        
        if(pin.CheckStrike())
        {
            Debug.Log("�X�g���C�N�I�I �{�[�i�X�F�t�@�C�A�[�{�[���ǉ�");
            queue.AddCommand(ct.Fireball);
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
        Debug.Log("�{�E�����O�I��");
        pin.AllRemovePin();
        //FixMe�F�{�[���������ʒu�ɖ߂��R�[�h�E�ړ���������
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
    }
    void Update()
    {
        
    }

}

