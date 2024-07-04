using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    private HeroScript hero;
    // Start is called before the first frame update
    void Start()
    {
        if(hero == null)
        {
            hero = FindObjectOfType<HeroScript>();
        }
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
                List<CommandType> deck = PinDeck.GetAllPinDeck();
                foreach (CommandType pin in deck)
                {
                    i++;
                    Debug.Log("デッキ" + i + "番目:" + pin);
                }
            }
            
        }
        //Deck
        if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            PinDeck.AddPinDeck(CommandType.Attack);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.B))
        {
            PinDeck.AddPinDeck(CommandType.Block);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
        {
            PinDeck.AddPinDeck(CommandType.Fireboll);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
        {
            PinDeck.Shuffle();
        }
        //Hero
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("H&M");
            if (hero != null)
            { 
                hero.AttackMotion();
            }
            else
            {
                Debug.Log("HeroScriptのインスタンスがありません");
            }
        }
        //Pin
        if(Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Super Pin").GetComponent<PinScript>().ArrangePins();
        }
        //GameManager
        if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.PlayStart();
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.PlayEnd();
        }
        //ball
        if(Input.GetKey(KeyCode.B) && Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<BallScript>().Set();
        }
        //Queue
        if (Input.GetKeyDown(KeyCode.Q))
        {
            List<CommandType> cmds = GameObject.Find("CommandQueue").GetComponent<CommandQueue>().commandQueue;
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

    }
}
