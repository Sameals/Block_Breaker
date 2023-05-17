using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "power", menuName = "power/Make New power")]
public class PowerUp : ScriptableObject
{
    public int Amount = 1;
    [SerializeField] GameObject prefab;
}
