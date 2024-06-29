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
                Debug.Log("デッキにはピンがありません");
            }
            else
            {
                List<PinType> deck = HeroPinDeck.GetAllPinDeck();
                foreach (PinType pin in deck)
                {
                    i++;
                    Debug.Log("デッキ" + i + "番目:" + pin);
                }
            }
            
        }
        //デッキにピン追加
        if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            HeroPinDeck.AddPinDeck(PinType.attackPin);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.B))
        {
            HeroPinDeck.AddPinDeck(PinType.blockPin);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
        {
            HeroPinDeck.AddPinDeck(PinType.magicPin);
        }
        //
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("H&M");
            if (heroScript != null)
            { 
                heroScript.HeroMove(10, 10);
            }
            else
            {
                Debug.Log("HeroScriptのインスタンスがありません");
            }
        }
        
    }
}
