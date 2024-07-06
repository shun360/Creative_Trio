using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items",menuName ="Item/food")]
public class Food : Item
{
    [SerializeField]
    private int hpChange;

    public int HpChange { get => hpChange; }
}
