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
        //캐릭터 이름
        nameText.text = characterInfo.name;

        //캐릭터 스프라이트
        characterSprite = characterInfo.character;
        string resource = characterSprite + "/" + characterSprite;
        mainSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(resource);
        mainSprite.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resource);
    }

    public void FixedUpdate()
    {
        //이름이 바뀔 때마다, 이름표 바꾸기
        if (!nameText.text.Equals(characterInfo.name))
        {
            nameText.text = characterInfo.name;
        }

        //캐릭터가 바뀔 때 마다, 캐릭터 애니메이션 바꾸기
        if (!characterSprite.Equals(characterInfo.name))
        {
            characterSprite = characterInfo.character;
            string resource = characterSprite + "/" + characterSprite;
            mainSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(resource);
            mainSprite.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resource);
        }
    }
}
