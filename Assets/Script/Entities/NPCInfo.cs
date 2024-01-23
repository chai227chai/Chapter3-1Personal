using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInfo : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public DialogInfo dialog;

    [SerializeField] private TextMeshProUGUI nameText;

    public void Awake()
    {
        nameText.text = characterInfo.name;

    }
}
