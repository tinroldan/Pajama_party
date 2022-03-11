using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public PlayerModel[] playerModels;
    public Transform spot;

    public List<GameObject> players;
    public int currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();

        foreach (var playerModel in playerModels)
        {
            GameObject go = Instantiate(playerModel.Player, spot.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(spot);
            players.Add(go);
        }
        ShowPlayerFromList();
    }


    void ShowPlayerFromList()
    {
        players[currentPlayer].SetActive(true);
    }

    public void OnClickNext()
    {
        players[currentPlayer].SetActive(false);
        if(currentPlayer < players.Count - 1)
        {
            currentPlayer++;
        }
        else
        {
            currentPlayer = 0;
        }
        ShowPlayerFromList();
    }

    public void OnClickPrevious()
    {
        players[currentPlayer].SetActive(false);
        if(currentPlayer == 0)
        {
            currentPlayer = players.Count - 1;
        }
        else
        {
            currentPlayer--;
        }
        ShowPlayerFromList();
    } 
}
