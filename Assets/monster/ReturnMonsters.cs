using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class StageMonsters : MonoBehaviour
{
    public static List<List<mt>> stage = new();//stage���Ƃɏo�����郂���X�^�[���i�[
    
    public List<mt> Stage(int stageNo)
    {
        return stage[stageNo];
    }
    // Start is called before the first frame update
    void Start()
    {
        stage.Add(new List<mt> { mt.Slime, mt.Slime });
        stage.Add(new List<mt> { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
