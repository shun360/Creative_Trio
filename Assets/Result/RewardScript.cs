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
                    text = "＜ファイアー＞\n魔法攻撃力で全体攻撃するピン";
                    break;
                case Re.PinRandomTripleAttack:
                    text = "＜乱れ打ち＞\n3回ランダムな敵に攻撃するピン";
                    break;
                case Re.PinTwiceAOE:
                    text = "＜旋風＞\n攻撃力で全体に2回攻撃するピン";
                    break;
                case Re.PinSmash:
                    text = "＜スマッシュ＞\n攻撃力の250%で攻撃するピン";
                    break;
                case Re.PinProtection:
                    text = "＜プロテクション＞\n防御力の200%のブロックを得るピン";
                    break;
                case Re.PinCurseATK:
                    text = "＜呪い＞\n敵全体の攻撃力を4下げるピン";
                    break;
                case Re.PinPenetration:
                    text = "＜風穴＞\n敵のブロックを破壊して攻撃するピン";
                    break;
                case Re.PinExtendATK:
                    text = "＜増幅＞\n戦闘が終わるまで攻撃力+3するピン";
                    break;
                case Re.PinExtendDEF:
                    text = "＜硬化＞\n戦闘が終わるまで防御力+2するピン";
                    break;
                case Re.PinOnlyOne:
                    mini = true;
                    text = "＜オンリーワン＞\n魔法攻撃力が20上がるが、ストライクボーナスが無くなる。\nこれを倒した上で、残りのピンが1個なら全体に魔法攻撃するピン";
                    break;
                case Re.BallGrow:
                    text = "＜成長＞\nボールが成長する";
                    break;
                case Re.BallAcce:
                    text = "＜ロケットスタート＞\nボールの発射速度が60%上昇する";
                    break;
                case Re.BallCont:
                    text = "＜念力＞\nボールを投げた後の左右コントロールが200%上昇する";
                    break;
                case Re.HeroGrowATK:
                    text = "＜鍛錬＞\n元の攻撃力が5上がる";
                    break;
                case Re.HeroGrowDEF:
                    text = "＜集中＞\n元の防御力が5上がる";
                    break;
                case Re.HeroGrowMagic:
                    text = "＜充填＞\n元の魔法攻撃力が15上がる";
                    break;
                case Re.HeroMetal:
                    text = "＜金属化＞\n毎ターン元の防御力のブロックを得る";
                    break;
                case Re.HeroHeal:
                    text = "＜治癒＞\n体力が全回復する";
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
