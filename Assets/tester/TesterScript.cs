using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                List<PinTypes.PinType> deck = HeroPinDeck.GetAllPinDeck();
                foreach (PinTypes.PinType pin in deck)
                {
                    i++;
                    Debug.Log("�f�b�L" + i + "�Ԗ�:" + pin);
                }
            }
            
        }
        //�f�b�L�Ƀs���ǉ�
        if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            HeroPinDeck.AddPinDeck(PinTypes.PinType.attackPin);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.B))
        {
            HeroPinDeck.AddPinDeck(PinTypes.PinType.blockPin);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.M))
        {
            HeroPinDeck.AddPinDeck(PinTypes.PinType.magicPin);
        }
        //
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.M))
        {
            Vector3 target = new Vector3(10, 10, 0);
            //GameObject.Find("Hero").HeroScript.HeroMove(target);
        }
        
    }
}
