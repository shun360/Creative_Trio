using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Result;
using UnityEngine.UI;
using TMPro;

public class RewardScript : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject reminder;
    public List<GameObject> buttonList;
    public HeroScript hero;
    public PinDeck pind;
    public BallScript ball;
    public List<Re> allRewards;
    public List<Re> yetRewards;
    public List<Re> selectedRewards;
    
    public Re select;
    public string text;
    public bool click;
    private static readonly Vector3 p = new(0, 370, 0);
    public static readonly Vector3[] positions =
    {
        p,
        new(p.x, p.y - 370, p.z),
        new(p.x, p.y - 740, p.z)
    };
    private void Awake()
    {
        buttonPrefab = (GameObject)Resources.Load("Button");
        hero = FindObjectOfType<HeroScript>();
        pind = FindObjectOfType<PinDeck>();
        ball = FindObjectOfType<BallScript>();
        buttonList = new();
        click = false;
        reminder = GameObject.Find("Reminder");
        reminder.SetActive(false);
    }
    private void Start()
    {

        allRewards = new List<Re>((Re[])System.Enum.GetValues(typeof(Re)));
        yetRewards = new List<Re>((Re[])System.Enum.GetValues(typeof(Re)));

    }
    public IEnumerator RewardSelect()
    {
        List<Re> rewards = RandomSelectThree();
        yield return DispButtun(rewards);
    }
    public List<Re> RandomSelectThree()
    {
        List<Re> temp = new List<Re>();
        int index =0;
        for (int i = 0;i < 3; i++)
        {
            index = Random.Range(0, yetRewards.Count);
            Re rew = yetRewards[index];
            temp.Add(rew);
            yetRewards.Remove(rew);
        }

        return temp;
    }
    public IEnumerator DispButtun(List<Re> rewards)
    {
        click = false;
        for(int i = 0; i < positions.Length; i++)
        {
            reminder.SetActive(true);
            GameObject button = Instantiate(buttonPrefab, positions[i],Quaternion.identity);
            bool mini = false;
            text = button.GetComponentInChildren<TMP_Text>().text;
            switch (rewards[i])
            {
                case Re.PinFire:
                    text = "���t�@�C�A�[��\n���@�U���͂őS�̍U������s��";
                    break;
                case Re.PinRandomTripleAttack:
                    text = "������ł���\n3�񃉃��_���ȓG�ɍU������s��";
                    break;
                case Re.PinTwiceAOE:
                    text = "��������\n�U���͂őS�̂�2��U������s��";
                    break;
                case Re.PinSmash:
                    text = "���X�}�b�V����\n�U���͂�250%�ōU������s��";
                    break;
                case Re.PinProtection:
                    text = "���v���e�N�V������\n�h��͂�200%�̃u���b�N�𓾂�s��";
                    break;
                case Re.PinCurseATK:
                    text = "���􂢁�\n�G�S�̂̍U���͂�4������s��";
                    break;
                case Re.PinPenetration:
                    text = "��������\n�G�̃u���b�N��j�󂵂čU������s��";
                    break;
                case Re.PinExtendATK:
                    text = "��������\n�퓬���I���܂ōU����+3����s��";
                    break;
                case Re.PinExtendDEF:
                    text = "���d����\n�퓬���I���܂Ŗh���+2����s��";
                    break;
                case Re.PinOnlyOne:
                    mini = true;
                    text = "���I�����[������\n���@�U���͂�20�オ�邪�A�X�g���C�N�{�[�i�X�������Ȃ�B\n�����|������ŁA�c��̃s����1�Ȃ�S�̂ɖ��@�U������s��";
                    break;
                case Re.BallGrow:
                    text = "��������\n�{�[������������";
                    break;
                case Re.BallAcce:
                    text = "�����P�b�g�X�^�[�g��\n�{�[���̔��ˑ��x��60%�㏸����";
                    break;
                case Re.BallCont:
                    text = "���O�́�\n�{�[���𓊂�����̍��E�R���g���[����200%�㏸����";
                    break;
                case Re.HeroGrowATK:
                    text = "���b�B��\n���̍U���͂�5�オ��";
                    break;
                case Re.HeroGrowDEF:
                    text = "���W����\n���̖h��͂�5�オ��";
                    break;
                case Re.HeroGrowMagic:
                    text = "���[�U��\n���̖��@�U���͂�15�オ��";
                    break;
                case Re.HeroMetal:
                    text = "����������\n���^�[�����̖h��͂̃u���b�N�𓾂�";
                    break;
                case Re.HeroHeal:
                    text = "��������\n�̗͂��S�񕜂���";
                    break;
            }
            int index = i;
            if (mini)
            {
                button.GetComponentInChildren<TMP_Text>().fontSize = 45;
            }
            button.GetComponentInChildren<TMP_Text>().text = text;

            button.transform.SetParent(transform, false);
            
            button.GetComponent<Button>().onClick.AddListener(() => RewardExe(rewards[index]));
            
            buttonList.Add(button);
        }
        
        yield return new WaitUntil(() => click);
        for (int i = buttonList.Count - 1; i >= 0; i--)
        {
            Destroy(buttonList[i]);
            buttonList.RemoveAt(i);
        }
        reminder.SetActive(false);


    }
    public void RewardExe(Re r,bool test = false)
    {
        switch (r)
        {
            case Re.PinFire:
                pind.AddFire();
                break;
            case Re.PinRandomTripleAttack:
                pind.AddRandomTripleAttack();
                break;
            case Re.PinTwiceAOE:
                pind.AddTwiceAOE();
                break;
            case Re.PinSmash:
                pind.AddSmash();
                break;
            case Re.PinProtection:
                pind.AddProtection();
                break;
            case Re.PinCurseATK:
                pind.AddCurseATK();
                break;
            case Re.PinPenetration:
                pind.AddPenetration();
                break;
            case Re.PinExtendATK:
                pind.AddExtendATK();
                break;
            case Re.PinExtendDEF:
                pind.AddExtendDEF();
                break;
            case Re.PinOnlyOne:
                pind.AddOnlyOne();
                break;
            case Re.BallGrow:
                ball.Grow();
                break;
            case Re.BallAcce:
                ball.DoubleAcceleration();
                break;
            case Re.BallCont:
                ball.DoubleControl();
                break;
            case Re.HeroGrowATK:
                hero.GrowATK();
                break;
            case Re.HeroGrowDEF:
                hero.GrowDEF();
                break;
            case Re.HeroGrowMagic:
                hero.GrowMagiATK();
                break;
            case Re.HeroMetal:
                hero.Metal();
                break;
            case Re.HeroHeal:
                hero.FullHeal();
                break;
        }
        if (!test)
        {
            click = true;
        }
    }
}
