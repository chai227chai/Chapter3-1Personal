using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SetPlayer : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public UIPopupManager uiManager;

    public TMP_InputField inputField;

    public GameObject playerCharacter;
    public GameObject warning;

    private string name;

    private bool isTextCorrect = false;


    public void Start()
    {
        //inputField.onValueChanged.AddListener(delegate { OnValueChange(inputField); });
    }

    public void ChangeName()
    {
        name = inputField.text;
        characterInfo.name = name;
    }

    //���� ���� ��
    public void OnJoinButton()
    {
        if (isTextCorrect)
        {
            ChangeName();
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            warning.SetActive(true);
        }
    }

    //�̸� ���� ��ư ���� ��
    public void OnChangeButton(GameObject ui)
    {
        if (isTextCorrect)
        {
            ChangeName();
            uiManager.CloseUi(ui);
        }
        else
        {
            warning.SetActive(true);
        }
    }

    //�̸� �Է�â���� 2���� �̻����� üũ
    public void OnValueChange()
    {
        string txt = inputField.text;
        if(txt.Length < 2)
        {
            warning.SetActive(true);
            isTextCorrect = false;
        }
        else
        {
            warning.SetActive(false);
            isTextCorrect = true;
        }
    }

    //ĳ���� �ٲٱ�
    public void ConfirmCharacter(GameObject ui)
    {
        GameObject characterImage = EventSystem.current.currentSelectedGameObject.transform.Find("character").gameObject;

        characterInfo.character = characterImage.GetComponent<Image>().sprite.name;
        if (playerCharacter.GetComponent<SpriteRenderer>() != null)
        {
            playerCharacter.GetComponent<SpriteRenderer>().sprite = characterImage.GetComponent<Image>().sprite;
        }
        else if (playerCharacter.GetComponent<Image>() != null)
        {
            playerCharacter.GetComponent<Image>().sprite = characterImage.GetComponent<Image>().sprite;
        }

        uiManager.CloseUi(ui);
    }


}
