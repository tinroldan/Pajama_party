using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupCam : MonoBehaviour
{
    [SerializeField] private Focus focus;
    [Header("Jugadores")]
    [SerializeField] private List<Transform> players;

    [Header("Vel Zoom")]
    [SerializeField] private float depth_update_speed;
    [Header("Vel Vertical")]
    [SerializeField] private float angle_update_speed;
    [Header("Vel Horizontal")]
    [SerializeField] private float position_update_speed;

    [Header("Variables Zoom")]
    [SerializeField] private float depth_max;
    [SerializeField] private float depth_min;

    private float camera_eulerX;
    private Vector3 camera_pos;
    // Start is called before the first frame update
    void Start()
    {
        var p = GameObject.FindGameObjectsWithTag("Player");
        players = new List<Transform>();
        for (int i = 0; i < p.Length; i++)
        {
            players.Add(p[i].GetComponent<Transform>());
        }
        players.Add(focus.transform);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraCalculation();
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 position = gameObject.transform.position;
        if (position != camera_pos)
        {
            Vector3 target_pos = Vector3.zero;
            target_pos.x = Mathf.MoveTowards(position.x, camera_pos.x, position_update_speed * Time.deltaTime);
            target_pos.y = Mathf.MoveTowards(position.y, camera_pos.y, position_update_speed * Time.deltaTime);
            target_pos.z = Mathf.MoveTowards(position.z, camera_pos.z, depth_update_speed * Time.deltaTime);

            gameObject.transform.position = target_pos;
        }

        Vector3 local_eulerAngles = gameObject.transform.localEulerAngles;
        if (local_eulerAngles.x != camera_eulerX)
        {
            Vector3 targetEulerAngles = new Vector3(camera_eulerX, local_eulerAngles.y, local_eulerAngles.z);
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(local_eulerAngles, targetEulerAngles, angle_update_speed * Time.deltaTime);
        }
        
    }

    private void CameraCalculation()
    {
        Vector3 average_center = Vector3.zero;
        Vector3 total_positions = Vector3.zero;
        Bounds players_bounds = new Bounds();

        for(int i = 0; i < players.Count; i++)
        {
            Vector3 player_pos = players[i].position;
            if (!focus.focusBounds.Contains(player_pos))//Revisa si esta dentro de los limites de la camara
            {
                float playerX = Mathf.Clamp(player_pos.x, focus.focusBounds.min.x, focus.focusBounds.max.x);
                //float playerY = Mathf.Clamp(player_pos.y, focus.focusBounds.min.y, focus.focusBounds.max.y);
                float playerY = 30;
                float playerZ = Mathf.Clamp(player_pos.z, focus.focusBounds.min.z, focus.focusBounds.max.z);

                player_pos = new Vector3(playerX, playerY, playerZ);
            }
            total_positions += player_pos;
            players_bounds.Encapsulate(player_pos);
        }
        average_center = (total_positions / players.Count);
        focus.transform.position = new Vector3(average_center.x, 0, average_center.z);


        float extents = (players_bounds.extents.x + players_bounds.extents.z);
        float lerpPercent = Mathf.InverseLerp(0, (focus.half_X_bounds + focus.half_Z_bounds) / 2/*Grados de libertad para los jugadores, pero preferible modificar los limites del FOCUS*/, extents);

        float depth = Mathf.Lerp(depth_max, depth_min, lerpPercent);
        float angle = 60;

        camera_eulerX = angle;
        camera_pos = new Vector3(average_center.x, average_center.z, depth);

    }
}
