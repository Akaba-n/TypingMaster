﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Room検索画面管理クラス
public class RoomSearchManager : MonoBehaviour {

    [SerializeField] RoomSearchUIManager rsUI;
    [SerializeField] RoomSearchPlayerActionManager rspa;

    /// <summary>
    /// Room検索画面処理
    /// </summary>
    public void RoomSearch() {

        rspa.RoomSearchPlayerAction();
        rsUI.RoomSearchUI();
    }
}