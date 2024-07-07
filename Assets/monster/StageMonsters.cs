using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class ReturnMonsters : MonoBehaviour
{
    public static List<List<mt>> monsters = new(); //stage���Ƃɏo�����郂���X�^�[���i�[
    
    public List<mt> StageMonsters(int stageNo) //stage�ԍ�(���̂܂�)������Ƃ��̃X�e�[�W�ɏo�������X�^�[list��Ԃ�
    {
        if (0 < stageNo  && stageNo <= monsters.Count)
        {
            return monsters[stageNo - 1];
        }
        else
        {
            return new List<mt> { mt.Slime };
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        monsters.Add(new List<mt> { mt.Slime, mt.Slime}); //stage1
        monsters.Add(new List<mt> { mt.Bat, mt.Slime});
        monsters.Add(new List<mt> { mt.Mummy });
        monsters.Add(new List<mt> { mt.Bat, mt.Bat, mt.Bat});
        monsters.Add(new List<mt> { mt.Gargoyle}); //stage5(�{�X)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
