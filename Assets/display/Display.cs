using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public IEnumerator StageStart()
    {
        //TODO�F�X�e�[�W�J�n�\��
        Debug.Log("�X�e�[�W�J�n��\��");
        yield return new WaitForSeconds(1f);
        Debug.Log("�X�e�[�W�J�n�\���I��");
        //�\���I��
    }
    public IEnumerator Clear()
    {
        //TODO�F�X�e�[�W�N���A�\��
        Debug.Log("�X�e�[�W�N���A��\��");
        yield return new WaitForSeconds(1f);
        Debug.Log("�X�e�[�W�N���A�\���I��");
        //�\���I��
    }
    public IEnumerator Turn()
    {
        //TODO�F���݂̃^�[������傫���\��
        Debug.Log("�^�[�����\��");
        yield return new WaitForSeconds(1f);
        Debug.Log("�^�[�����\���I��");
        //TODO�F�\���I��
    }
}
