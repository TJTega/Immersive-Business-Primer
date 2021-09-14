using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubsceneAssets", menuName = "Scriptable Objects/Subscene Asset List", order = 1)]
public class SubsceneAssets : ScriptableObject
{
    ///<summary>Array holding assets for floors</summary>
    public List<GameObject> elements = new List<GameObject>();
}
