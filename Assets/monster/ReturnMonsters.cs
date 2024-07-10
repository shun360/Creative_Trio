using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class ReturnMonsters : MonoBehaviour
{
    public static List<List<mt>> monsters; //stage���Ƃɏo�����郂���X�^�[���i�[
    
    public List<mt> StageMonsters(int stageNo) //stage�ԍ�(���̂܂�)������Ƃ��̃X�e�[�W�ɏo�������X�^�[list��Ԃ�
    {
        if (0 < stageNo  && stageNo <= monsters.Count)
        {
            return monsters[stageNo - 1];
        }
        else
        {
            Debug.LogError("�͈͊O�̃X�e�[�W���ǂݍ��܂�܂���");
            return new List<mt> { mt.NoneMonster };
        }
    }
    void Awake()
    {
        monsters = new List<List<mt>>//1�̃X�e�[�W�ɂ�3�̂܂�
        {
            new() { mt.Slime, mt.Slime }, //stage1
            new() { mt.Bat, mt.Slime },
            new() { mt.Mummy },
            new() { mt.Bat, mt.Bat, mt.Bat },
            new() { mt.Gargoyle } //stage5(�{�X)
        };
    }

    
}
