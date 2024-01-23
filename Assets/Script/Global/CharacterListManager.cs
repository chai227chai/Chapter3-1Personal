using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterListManager : MonoBehaviour
{
    public List<string> nowCharacterList = new List<string>();

    [SerializeField] private GameObject characters;
    [SerializeField] private TextMeshProUGUI nowCharacterName;

    void SetList()
    {
        nowCharacterList.Clear();
        foreach (Transform child in characters.transform)
        {
            //가장 수정하고 싶은 부분
            string name = "";
            if (child.GetComponent<PlayerInfo>() != null)
            {
                name = child.GetComponent<PlayerInfo>().characterInfo.name;
            }

            if(child.GetComponent<NPCInfo>() != null)
            {
                name = child.GetComponent<NPCInfo>().characterInfo.name;
            }
            //

            nowCharacterList.Add(name);
        }
    }

    void ShowList()
    {
        //캐릭터 리스트 리셋
        foreach(Transform child in GameObject.Find("UI").transform.Find("Canvas/SideBar/Names").transform)
        {
            Destroy(child.gameObject);
        }

        //스크롤바를 적용시키고 싶음
        int index = 0;
        foreach(string text in nowCharacterList)
        {
            TextMeshProUGUI characterName = Instantiate(nowCharacterName);

            characterName.transform.SetParent(GameObject.Find("UI").transform.Find("Canvas/SideBar/Names").transform);

            float y = (index * -16f) + -14f;
            characterName.text = text;
            characterName.rectTransform.anchoredPosition = new Vector3(0, y, 0);

            index++;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //새로운 캐릭터 입장 혹은 캐릭터 퇴장 시
        if (nowCharacterList.Count != characters.transform.childCount)
        {
            UpdateList();
        }
    }

    public void UpdateList()
    {
        SetList();
        ShowList();
    }
}
