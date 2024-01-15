#if UNITY_EDITOR
using ParrelSync;
using UnityEditor;
#endif
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Collections.Generic;

public class ConnectionStarter : MonoBehaviourPunCallbacks
{
    public static ConnectionStarter Instance;

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;

    private void Awake()
    {
        Instance = this;
    }

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
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("LoadingMenu");
	Debug.Log("Create room");
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

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("Loading");
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

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().Initialize(roomList[i]);
        }
    }

}
