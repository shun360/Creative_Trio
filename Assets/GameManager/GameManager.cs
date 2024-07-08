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
            //TODO�FstageNo�̃����X�^�[���o��
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
        //TODO�FLevelUp!�U����+1�A�h���+1����
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
            //FixMe�F�{�[���������ʒu�ɖ߂��R�[�h
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
            FindObjectOfType<PinScript>().AllRemovePin();
            //FixMe�F�{�[���������ʒu�ɖ߂��R�[�h
            FindObjectOfType<BallScript>().Set();
            
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

