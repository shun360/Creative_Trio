using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public IEnumerator Turn()
    {
        //TODO�F���݂̃^�[������傫���\��
        Debug.Log("�^�[�����\��");
        yield return new WaitForSeconds(1f);
        Debug.Log("�^�[�����\���I��");
        //TODO�F�\���I��
    }
}
