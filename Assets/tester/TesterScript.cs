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
                Debug.Log("デッキにはピンがありません");
            }
            else
            {
                List<PinTypes.PinType> deck = HeroPinDeck.GetAllPinDeck();
                foreach (PinTypes.PinType pin in deck)
                {
                    i++;
                    Debug.Log("デッキ" + i + "番目:" + pin);
                }
            }
            
        }
        if(Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            HeroPinDeck.AddPinDeck(PinTypes.PinType.attackPin);
            
        }

    }
}
