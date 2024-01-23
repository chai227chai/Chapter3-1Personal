using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public CharacterInfo characterInfo;
    private string characterSprite;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject mainSprite;
    

    public void Awake()
    {
        //ĳ���� �̸�
        nameText.text = characterInfo.name;

        //ĳ���� ��������Ʈ
        characterSprite = characterInfo.character;
        string resource = characterSprite + "/" + characterSprite;
        mainSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(resource);
        mainSprite.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resource);
    }

    public void FixedUpdate()
    {
        //�̸��� �ٲ� ������, �̸�ǥ �ٲٱ�
        if (!nameText.text.Equals(characterInfo.name))
        {
            nameText.text = characterInfo.name;
        }

        //ĳ���Ͱ� �ٲ� �� ����, ĳ���� �ִϸ��̼� �ٲٱ�
        if (!characterSprite.Equals(characterInfo.name))
        {
            characterSprite = characterInfo.character;
            string resource = characterSprite + "/" + characterSprite;
            mainSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(resource);
            mainSprite.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resource);
        }
    }
}
