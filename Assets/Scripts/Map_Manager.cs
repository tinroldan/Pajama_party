using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Manager : MonoBehaviour
{
    [SerializeField] public GameObject[] maps;
    GameObject[] players;
    public static bool change_mp;
    [Range(0,1)]
    int counter;
    [SerializeField] private GameObject score_panel;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    private void FixedUpdate()
    {
        if (change_mp && counter == 1)
        {
            counter = 0;
            ChangeMap();
        }
        else if (change_mp == false && counter == 0)
        {
            counter = 1;
            DisableCanvas();
        }
        else return;
    }

    private void DisableCanvas()
    {
        score_panel.SetActive(false);
    }

    private void ChangeMap()
    {
        score_panel.SetActive(true);
        int rnd = Random.Range(0, maps.Length-1);
        for(int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        maps[rnd].SetActive(true);
        Teleport_players(rnd);
    
    }
    private void Teleport_players(int rnd)
    {
        int spawns = maps[rnd].transform.GetChild(0).transform.childCount;
        Transform[] spawnpoints = new Transform[spawns];
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            spawnpoints[i] = maps[rnd].transform.GetChild(0).GetChild(i).transform;
        }
        for(int i = 0; i < players.Length; i++)
        {
            players[i].transform.position = spawnpoints[i].position;
        }
    }
}
