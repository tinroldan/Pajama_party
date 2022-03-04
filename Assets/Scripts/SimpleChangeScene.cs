using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SimpleChangeScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLobby()
    {
        PhotonNetwork.Disconnect();
    }

    

}
