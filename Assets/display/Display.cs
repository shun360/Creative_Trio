using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    public IEnumerator StageStart()
    {
        //TODO：ステージ開始表示
        Debug.Log("ステージ開始を表示");
        yield return new WaitForSeconds(1f);
        Debug.Log("ステージ開始表示終了");
        //表示終了
    }
    public IEnumerator Clear()
    {
        //TODO：ステージクリア表示
        Debug.Log("ステージクリアを表示");
        yield return new WaitForSeconds(1f);
        Debug.Log("ステージクリア表示終了");
        //表示終了
    }
    public IEnumerator Turn()
    {
        //TODO：現在のターン数を大きく表示
        Debug.Log("ターン数表示");
        yield return new WaitForSeconds(1f);
        Debug.Log("ターン数表示終了");
        //TODO：表示終了
    }
}
