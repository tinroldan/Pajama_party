using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    private float target_zoom;
    [Header("Variables Zoom")]
    [SerializeField] private float zoom_factor;
    [SerializeField] private float zoomLerpSpeed;
    [Header("Zoom In")]
    [SerializeField] private float min_size;
    [Header("Zoom Out")]
    [SerializeField] private float max_size;

    GameObject[] players;
    [SerializeField] float scroll;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        target_zoom = cam.orthographicSize;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        for(int i = 0; i < players.Length; i++)
        {
            
        }

        target_zoom -= scroll * zoom_factor;
        target_zoom = Mathf.Clamp(target_zoom,min_size, max_size);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, target_zoom, Time.deltaTime * zoomLerpSpeed);
    }
}
