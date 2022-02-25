using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Camera : MonoBehaviour
{
    [Header("Jugadores")]
    [SerializeField] private List<Transform> players;
    Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Transform>();
        var p = GameObject.FindGameObjectsWithTag("Player");
        players = new List<Transform>();
        for (int i = 0; i < p.Length; i++)
        {
            players.Add(p[i].GetComponent<Transform>());
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraCalculation();
    }
    private void CameraCalculation()
    {
        if (players == null || players.Count == 0) return;
        Vector3 average_center = Vector3.zero;
        Vector3 total_positions = Vector3.zero;

        for (int i = 0; i < players.Count; i++)
        {
            Vector3 player_pos = players[i].position;
            total_positions += new Vector3(player_pos.x,0f,player_pos.z);
        }
        average_center = (total_positions / players.Count);
        camera.position = average_center;
    }
}
