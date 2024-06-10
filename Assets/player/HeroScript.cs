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
    private int heroBlock = 0;

    private Vector2 currentPosi;
    [SerializeField] private Transform moveTarget;
    [SerializeField] private float smoothTime;
    private Vector2 currentSpeed;
    
    //getter, setter
    public int getHeroHP() {  return heroHP; }
    public int getHeroATK() {  return heroATK; }
    public int getHeroDEF() {  return heroDEF; }
    public int getHeroMagiATK() { return heroMagiATK; }
    public int getHeroBlock() {  return heroBlock; }
    public void setHeroHP(int hp) {  heroHP = hp; }
    public void setHeroATK(int atk) {  heroATK = atk; }
    public void setHeroDEF(int def) {  heroDEF = def; }
    public void setHeroMagiATK(int magiATK) { heroMagiATK= magiATK; }
    public void setHeroBlock(int block) {  heroBlock = block; }
    //other method
    public void addHeroBlock() { heroBlock += heroDEF; }//ブロック値をプラスする
    public void beAttacked(int damage) { 

        //heroHP -= (damage - ); 
    }//攻撃を受ける

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
