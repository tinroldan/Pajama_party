using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    [Range(0, 2)] 
    [Tooltip("Speed = 0, Shield = 1, Teleport = 2")]
    [SerializeField] int powerUpID;
    private Movement _player;

    public Button TeleportButton;
    private void Awake()
    {
        _player = FindObjectOfType<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (_player != null)
            {
                switch (powerUpID)
                {
                    case 0:
                        StartCoroutine(_player.SpeedPowerUp());
                        Destroy(this.gameObject);
                        break;
                    case 1:
                        _player.ShieldPowerUp();
                        Destroy(this.gameObject);
                        break;
                    case 2:
                        Destroy(this.gameObject);
                        TeleportButton.gameObject.SetActive(true);
                        //_player.TeleportPowerUp();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
}
