using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    Map_Manager map_manager;
    [SerializeField] GameObject power_up;
    [SerializeField] private float spawn_time;
    private float time;
    private int rnd;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        map_manager = GetComponent<Map_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawn_time)
        {
            time = 0;
            SpawnPowerUp();
        }
        if (Map_Manager.change_mp) time = 0;
    }

    private void SpawnPowerUp()
    {
        int spawns = map_manager.maps[map_manager.current_map].transform.GetChild(1).transform.childCount;
        Transform[] spawnpoints = new Transform[spawns];
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            spawnpoints[i] = map_manager.maps[map_manager.current_map].transform.GetChild(1).GetChild(i).transform;
        }
        int past_rnd = rnd;
        rnd =  Random.Range(0, spawns);
        while (past_rnd == rnd) rnd = Random.Range(0, spawns);
        Instantiate(power_up, spawnpoints[rnd]);
        Debug.Log(rnd);

    }
}
