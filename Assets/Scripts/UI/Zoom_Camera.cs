using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Camera : MonoBehaviour
{
    [Header("Jugadores")]
    [SerializeField] private List<Transform> players;
    [SerializeField] Vector3 initial_pos, zoom_pos;
    int count_number;
    [Range(0,1)]
    float lerp_percent;
    float max_distance;
    bool dead_player;
    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position;
        var p = GameObject.FindGameObjectsWithTag("Player");
        players = new List<Transform>();
        for (int i = 0; i < p.Length; i++)
        {
            players.Add(p[i].GetComponent<Transform>());
        }
        CalculateMaxDistance();
    }
    private void CalculateMaxDistance()
    {
        float total_distance = 0;
        count_number = 0;
        Vector3 player_pos = Vector3.zero;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].gameObject.activeSelf == false && Mov_Camera.local== false) players.Remove(players[i]);
            else if (players[i].gameObject.activeSelf == false && Mov_Camera.local== true)
            {
                total_distance += 50;
            }
            else player_pos = players[i].position;

            for (int j = i + 1; j < players.Count; j++)
            {
                if (players[j].gameObject.activeSelf == false && Mov_Camera.local == false) players.Remove(players[j]);
                else if (players[i].gameObject.activeSelf == false && Mov_Camera.local == true)
                {
                    total_distance += 50;
                }
                else
                {
                    Vector3 enemy_pos = players[j].position;
                    total_distance += Mathf.Abs(Vector3.Distance(enemy_pos, player_pos));
                    count_number++;
                }
         

            }
        }
        max_distance = total_distance / count_number;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ZoomCalculation();
    }

    private void ZoomCalculation()
    {
        if (players == null || players.Count <= 1) return;
        float average_distance = 0;
        float total_distance = 0;
        count_number = 0;
        Vector3 player_pos = Vector3.zero;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].gameObject.activeSelf == false && Mov_Camera.local == false) players.Remove(players[i]);
            else if (players[i].gameObject.activeSelf == false && Mov_Camera.local == true) dead_player = true;
            else
            {
                player_pos = players[i].position;
                dead_player = false;
            }
            for (int j = i + 1; j < players.Count; j++)
            {
                if (players[j].gameObject.activeSelf == false && Mov_Camera.local == false) players.Remove(players[j]);
                else if (players[j].gameObject.activeSelf == false && Mov_Camera.local == true) dead_player = true;
                else
                {
                    Vector3 enemy_pos = players[j].position;
                    total_distance += Mathf.Abs(Vector3.Distance(enemy_pos, player_pos));
                    count_number++;
                    dead_player = false;
                }

            }
        }
        average_distance = total_distance / count_number;
        if (average_distance > max_distance) max_distance = average_distance;
        lerp_percent = average_distance / max_distance*2;
        if (dead_player) lerp_percent = 1;
        transform.localPosition = Vector3.Lerp(zoom_pos, initial_pos, lerp_percent);
    }
}
