using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "CharacterInfoManager/CharacterInfo", order = 0)]
public class CharacterInfo : ScriptableObject
{
    public string name;
    public string character;
}
