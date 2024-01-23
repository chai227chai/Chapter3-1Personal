using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform Player { get; private set; }
    public Transform NPC { get; private set; }

    [SerializeField] private string PlayerTag = "Player";
    [SerializeField] private string NPCTag = "NPC";
    [SerializeField] private TextMeshProUGUI Time;

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag(PlayerTag).transform;
    }

    //가장 가까이 있는 NPC 탐색
    public GameObject FindNerestTarget(GameObject player)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(NPCTag);

        GameObject nearestObject = objects.OrderBy(x => { return Vector3.Distance(player.transform.position, x.transform.position); }).FirstOrDefault();

        return nearestObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime();
    }

    private void CurrentTime()
    {
        Time.text = DateTime.Now.ToString("HH : mm");
    }
}
