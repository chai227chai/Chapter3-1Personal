using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UIShowManager : MonoBehaviour
{
    public static UIShowManager instance;

    [SerializeField] GameObject player;// 플레이어를 기준으로 대사창 생성

    public GameObject ringtheBell;
    public GameObject dialogMessage;
    public GameObject OtherUI;

    GameManager gameManager;

    public bool canTalk = false;
    public bool alreadyTalked = false;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(player.transform.position, gameManager.FindNerestTarget(player).transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DistanceToTarget() < 4f)
        {
            canTalk = true;
            ShowDialogPop();
        }
        else
        {
            canTalk = false;
            alreadyTalked = false;
        }

        ShowDialogPop();
        ShowDialog();
    }

    private void ShowDialogPop()
    {
        ringtheBell.GetComponentInChildren<TextMeshProUGUI>().text = gameManager.FindNerestTarget(player).GetComponent<NPCInfo>().characterInfo.name;

        if (canTalk && !alreadyTalked)
        {
            ringtheBell.SetActive(true);
        }
        else
        {
            ringtheBell.SetActive(false);
        }
    }

    //대화중일땐 다른 ui 끄기
    public void ShowDialog()
    {
        if (alreadyTalked)
        {
            dialogMessage.SetActive(true);
            OtherUI.SetActive(false);
        }
        else
        {
            dialogMessage.SetActive(false);
            OtherUI.SetActive(true);
        }
    }

    public void Talk()
    {
        dialogMessage.transform.Find("name").GetComponent<TextMeshProUGUI>().text = gameManager.FindNerestTarget(player).GetComponent<NPCInfo>().characterInfo.name;
        dialogMessage.transform.Find("dialog").GetComponent<TextMeshProUGUI>().text = gameManager.FindNerestTarget(player).GetComponent<NPCInfo>().dialog.dialog;
        alreadyTalked = true;
    }

    public void StopTalk()
    {
        alreadyTalked = false;
    }

}
