using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    private HeroScript heroScript;
    // Start is called before the first frame update
    void Start()
    {
        if(heroScript == null)
        {
            heroScript = FindObjectOfType<HeroScript>();
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
        //�f�b�L�Ƀs���ǉ�
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
        //
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("H&M");
            if (heroScript != null)
            { 
                heroScript.HeroAttackMotion();
            }
            else
            {
                Debug.Log("HeroScript�̃C���X�^���X������܂���");
            }
        }
        
    }
}
