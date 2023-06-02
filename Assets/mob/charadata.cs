using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StusData")]
public class charadata : ScriptableObject
{
    public string NAME;//キャラ・敵名
    public int MAXHP;//最大HP
}