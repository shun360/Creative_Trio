using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class HeroScript : MonoBehaviour
{
    [SerializeField]public static HeroClass hero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    private bool shouldMove = false;
    private bool isReturning = false;
    Vector3 originPosition;

    private void HeroMove(float x, float y)
    {
        shouldMove = true;
        targetPosition = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        Debug.Log($"HeroMove���Ă΂ꂽ����targetPosition: {targetPosition}");
    }
    public void AttackMotion()
    {
        HeroMove(10, 10);
    }

    
    private void Awake()
    {
        hero = new HeroClass();
        originPosition = new Vector3(15, 15, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        transform.position = originPosition;
        AttackMotion();
        //HeroMove(10,10);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove)
        {
            if(isReturning)
            {
                if (Vector3.Distance(transform.position, originPosition) < 0.1f)
                {
                    shouldMove = false;
                    velocity = Vector3.zero;
                    isReturning = false;
                    Debug.Log("originPosition�ɖ߂���");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, originPosition, ref velocity, 0.1f);
                }
            }
            else
            { 
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                { 
                    isReturning = true;
                    targetPosition = originPosition;
                    Debug.Log("U�^�[������");
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
                }
            }
            
        }
        if(hero.NowHP <= 0)
        {
            Debug.Log("GAME OVER!");
            //�Q�[���I�[�o�[����������
            GameOver();
        }
    }
   void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    
}
