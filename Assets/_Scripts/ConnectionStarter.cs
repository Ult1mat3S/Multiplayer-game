#if UNITY_EDITOR
using ParrelSync;
using UnityEditor;
#endif
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ConnectionStarter : MonoBehaviourPunCallbacks
{
[SerializeField] TMP_InputField roomNameInputField;
[SerializeField] TMP_Text errorText;
[SerializeField] TMP_Text roomNameText;

    void Start()
    {
PhotonNetwork.ConnectUsingSettings();
    }

public override void OnConnectedToMaster()
{
    PhotonNetwork.JoinLobby();
}

public override void OnJoinedLobby()
{
MenuManager.Instance.OpenMenu("MainMenu");
}

public void CreateRoom()
{
    if(string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("LoadingMenu");
    }

public override void OnJoinedRoom()
{
MenuManager.Instance.OpenMenu("RoomMenu");
roomNameText.text = PhotonNetwork.CurrentRoom.Name;
}

public override void OnCreateRoomFailed(short returnCode, string message)
{
errorText.text = "Room Creation Failed: " + message;
MenuManager.Instance.OpenMenu("ErrorMenu");
}

public void LeaveRoom()
{
PhotonNetwork.LeaveRoom();
MenuManager.Instance.OpenMenu("Loading");
}

public override void OnLeftRoom()
{
    MenuManager.Instance.OpenMenu("MainMenu");
}
}
