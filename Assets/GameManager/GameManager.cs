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
                    StageClear();
                    
                }
            }
        }
        Debug.Log("�Q�[���N���A!!");
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
        Debug.Log("�X�e�[�W�N���A�I");
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
            throwStart = false;
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
            if(pin.CheckStrike())
            {
                Debug.Log("�X�g���C�N�I�I �{�[�i�X�F�t�@�C�A�[�{�[���ǉ�");
                queue.AddCommand(ct.Fireball);
            }
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

