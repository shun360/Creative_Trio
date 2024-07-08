using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNo;
    public bool isPlaying;
    public int turn;
    public bool throwEnd;
    private Display disp;
    private HeroScript hero;
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
        hero = FindObjectOfType<HeroScript>();
        stageNo = 1;
        isPlaying = false;
        turn = 0;
        throwEnd = false;
        for (int i = 2; i < ReturnMonsters.monsters.Count + 2;i++)
        {
            StartCoroutine(disp.StageStart());
            mons.SetMonster();
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
        hero.LevelUp();
        //FixMe�FLevelUp���o
        //TODO�F��V��I��
    }
    public void PlayStart()//�{�E�����O�J�n
    {
        if (!isPlaying)
        {
            throwEnd = false;
            pin.ArrangePins();
            isPlaying = true;
            Debug.Log("�{�E�����O�X�^�[�g");
            //FixMe�F�{�[���������ʒu�ɖ߂��R�[�h�E�ړ���������
            ball.Set();
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
            pin.AllRemovePin();
            //FixMe�F�{�[���������ʒu�ɖ߂��R�[�h�E�ړ���������
            ball.Set();
            
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

