using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInpuField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] string modeSelectorMenu;
    void Start()
    {
        Debug.Log("Connecting Master...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Joined Lobby");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInpuField.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomNameInpuField.text);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room creation Failed: " + message;
        MenuManager.Instance.OpenMenu("error");

    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");

    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveLobby();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftLobby()
    {
        SceneManager.LoadScene(modeSelectorMenu);
        Destroy(this);
    }

}
