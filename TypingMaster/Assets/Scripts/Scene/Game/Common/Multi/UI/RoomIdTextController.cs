using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class RoomIdTextController : MonoBehaviour {

    [SerializeField] Text roomIdText;

    public void RoomIdText() {

        roomIdText.text = "Room:" + PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");
    }
}
