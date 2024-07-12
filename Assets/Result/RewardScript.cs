using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Result;
using UnityEngine.UI;
using TMPro;

public class RewardScript : MonoBehaviour
{
    public GameObject buttonPrefab;
    public List<GameObject> buttunList = new List<GameObject>();
    public HeroScript hero;
    public PinDeck pind;
    public BallScript ball;
    public List<Re> allRewards;
    public List<Re> yetRewards;
    public List<Re> selectedRewards;
    public Re select;
    public string text;
    public bool click = false;
    private static Vector3 p = new(0, 400, 0);
    public static Vector3[] positions =
    {
        p,
        new(p.x, p.y - 400, p.z),
        new(p.x, p.y - 800, p.z)
    };
    private void Awake()
    {
        buttonPrefab = (GameObject)Resources.Load("Button");
        hero = FindObjectOfType<HeroScript>();
        pind = FindObjectOfType<PinDeck>();
        ball = FindObjectOfType<BallScript>();
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
            GameObject button = Instantiate(buttonPrefab, positions[i],Quaternion.identity);

            text = button.GetComponentInChildren<TMP_Text>().text;
            switch (rewards[i])
            {
                case Re.PinFireball:
                    text = "";
                    break;
                case Re.PinRandomTripleAttack:
                    text = "";
                    break;
                case Re.PinTwiceAOE:
                    text = "";
                    break;
                case Re.PinSmash:
                    text = "";
                    break;
                case Re.PinProtection:
                    text = "";
                    break;
                case Re.PinCurseATK:
                    text = "";
                    break;
                case Re.PinPenetration:
                    text = "";
                    break;
                case Re.PinExtendATK:
                    text = "";
                    break;
                case Re.PinExtendDEF:
                    text = "";
                    break;
                case Re.PinOnlyOne:
                    text = "";
                    break;
                case Re.BallGrow:
                    text = "";
                    break;
                case Re.BallAcce:
                    text = "";
                    break;
                case Re.BallCont:
                    text = "";
                    break;
                case Re.HeroGrowATK:
                    text = "";
                    break;
                case Re.HeroGrowDEF:
                    text = "";
                    break;
                case Re.HeroGrowMagic:
                    text = "";
                    break;
                case Re.HeroMetal:
                    text = "";
                    break;
                case Re.HeroHeal:
                    text = "";
                    break;
                    //TODO:テキスト入力
            }
            int index = i;
            button.GetComponentInChildren<TMP_Text>().text = text;
            button.transform.SetParent(transform, false);
            button.GetComponent<Button>().onClick.AddListener(() => RewardExe(rewards[index]));
            buttunList.Add(button);
        }
        
        yield return new WaitUntil(() => click);
        for (int i = buttunList.Count - 1; i >= 0; i--)
        {
            Destroy(buttunList[i]);
            buttunList.RemoveAt(i);
        }


    }
    public void RewardExe(Re r)
    {
        //TODO:報酬メソッドにつなぐ
        switch (r)
        {
            case Re.PinFireball:
                pind.AddFireball();
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
        click = true;
    }
}
