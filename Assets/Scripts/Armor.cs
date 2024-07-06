using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items",menuName ="Items/armor")]
public class Armor : Item
{
    [SerializeField]
    private int atk;

    public int MyAtk { get => atk;}
}
