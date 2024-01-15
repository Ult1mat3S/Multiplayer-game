using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    RoomInfo info;

   public void Initialize(RoomInfo _info)
    {
        info = _info;
        text.text = info.Name; 
    }

    public void OnClick()
    {
        ConnectionStarter.Instance.JoinRoom(info);
    }
}
