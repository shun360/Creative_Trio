using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandType;

public class TesterScript : MonoBehaviour
{
    private HeroScript hero;
    private BallScript ball;
    private RewardScript reward;
    // Start is called before the first frame update
    void Awake()
    {
        if (hero == null)
        {
            hero = FindObjectOfType<HeroScript>();
        }
        ball = FindObjectOfType<BallScript>();
        reward = FindObjectOfType<RewardScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.P))
        {
            int i = 0;
            if (PinDeck.Deck is null)
            {
                Debug.Log("デッキにはピンがありません");
            }
            else
            {
                List<Ct> deck = PinDeck.GetAllPinDeck();
                foreach (Ct pin in deck)
                {
                    i++;
                    Debug.Log("デッキ" + i + "番目:" + pin);
                }
            }

        }
        //Deck
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            PinDeck.AddPinDeck(Ct.Attack);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.B))
        {
            PinDeck.AddPinDeck(Ct.Block);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
        {
            PinDeck.AddPinDeck(Ct.Fire);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
        {
            PinDeck.Shuffle();
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.R))
        {
            PinDeck.AddPinDeck(Ct.RandomTripleAttack);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.W))
        {
            PinDeck.AddPinDeck(Ct.TwiceAOE);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.N))
        {
            PinDeck.AddPinDeck(Ct.Penetration);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.H))
        {
            PinDeck.AddPinDeck(Ct.Smash);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.O))
        {
            PinDeck.AddPinDeck(Ct.Protection);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            FindObjectOfType<PinDeck>().AddOnlyOne();
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.C))
        {
            PinDeck.AddPinDeck(Ct.CurseATK);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.U))
        {
            PinDeck.AddPinDeck(Ct.ExtendATK);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.E))
        {
            PinDeck.AddPinDeck(Ct.ExtendDEF);
        }
        //Hero
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.D))
        {
            hero.TakeAttacked(50);
        }

        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(hero.LevelUp());
        }
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log($"現在のステータスはHPは{hero.nowHP}、攻撃力は{hero.nowATK}、防御力は{hero.nowDEF}です");
        }
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.R))
        {
            hero.FullHeal();
        }
        //Pin
        if (Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Super Pin").GetComponent<PinScript>().ArrangePins();
        }
        if (Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<PinScript>().AllRemovePin();
        }
        //GameManager
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.PlayStart();
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.PlayEnd();
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.StartGamePlay();
        }
        //ball
        if (Input.GetKey(KeyCode.B) && Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<BallScript>().Set();
        }

        if (Input.GetKey(KeyCode.B) && Input.GetKeyDown(KeyCode.A))
        {
            ball.DoubleAcceleration();
        }


        //Queue
        if (Input.GetKeyDown(KeyCode.Q))
        {
            List<Ct> cmds = GameObject.Find("CommandQueue").GetComponent<CommandQueue>().commandQueue;
            if (cmds.Count == 0)
            {
                Debug.Log("セットされているコマンドはありません。");
            }
            else
            {
                for (int i = 0; i < cmds.Count; i++)
                {
                    Debug.Log($"コマンドキューの{i}番目：{cmds[i]}");
                }
            }

        }
        //Monster
        if (Input.GetKey(KeyCode.M) && Input.GetKeyDown(KeyCode.D))
        {
            FindAnyObjectByType<MonsterScript>().DeleteMonsters();
        }
        //Reward
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }
}
