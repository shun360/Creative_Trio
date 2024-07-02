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
            if (HeroPinDeck.PinDeck is null)
            {
                Debug.Log("�f�b�L�ɂ̓s��������܂���");
            }
            else
            {
                List<CommandType> deck = HeroPinDeck.GetAllPinDeck();
                foreach (CommandType pin in deck)
                {
                    i++;
                    Debug.Log("�f�b�L" + i + "�Ԗ�:" + pin);
                }
            }
            
        }
        //Deck
        if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            HeroPinDeck.AddPinDeck(CommandType.Attack);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.B))
        {
            HeroPinDeck.AddPinDeck(CommandType.Block);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
        {
            HeroPinDeck.AddPinDeck(CommandType.Fireboll);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
        {
            HeroPinDeck.Shuffle();
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
                Debug.Log("HeroScript�̃C���X�^���X������܂���");
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

    }
}
