using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public GameObject BallPrefab;
    private Vector3 mousePos;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 18f;
            //É{Å[Éãê∂ê¨
            Instantiate(BallPrefab,
                Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        }
    }
}

