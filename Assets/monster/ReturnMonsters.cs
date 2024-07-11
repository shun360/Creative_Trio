using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterSet;

public class ReturnMonsters : MonoBehaviour
{
    public static List<List<Mt>> monsters; //stage���Ƃɏo�����郂���X�^�[���i�[
    
    public List<Mt> StageMonsters(int stageNo) //stage�ԍ�(���̂܂�)������Ƃ��̃X�e�[�W�ɏo�������X�^�[list��Ԃ�
    {
        if (0 < stageNo  && stageNo <= monsters.Count)
        {
            return monsters[stageNo - 1];
        }
        else
        {
            Debug.LogError("�͈͊O�̃X�e�[�W���ǂݍ��܂�܂���");
            return new List<Mt> { Mt.NoneMonster };
        }
    }
    void Awake()
    {
        monsters = new List<List<Mt>>//1�̃X�e�[�W�ɂ�3�̂܂�
        {
            new() { Mt.Slime, Mt.Slime }, //stage1
            new() { Mt.Bat, Mt.Slime },
            new() { Mt.Mummy },
            new() { Mt.Bat, Mt.Bat, Mt.Bat },
            new() { Mt.Gargoyle } //stage5(�{�X)
        };
    }

    
}
