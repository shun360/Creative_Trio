using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum CommandType
{
    Attack,
    Defense,
    Fireboll
}
public class NewBehaviourScript : MonoBehaviour
{
    private int heroHP = 100;
    private int heroATK = 8;
    private int heroDEF = 5;
    private int heroMagiATK = 15;
    private Vector2 currentPosi;
    [SerializeField] private Transform moveTarget;
    [SerializeField] private float smoothTime;
    private Vector2 currentSpeed;
    
    public int getHeroHP() {  return heroHP; }
    public int getHeroATK() {  return heroATK; }
    public void setHeroHP(int hp) {  heroHP = hp; }
    public void setHeroATK(int atk) {  heroATK = atk; }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        transform.position = new Vector3(15, 15, 0);

    }


    // Update is called once per frame
    void Update()
    {


    }
}
