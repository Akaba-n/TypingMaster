using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelectManager : MonoBehaviour {

    [SerializeField] private MenuMain mm;
    [SerializeField] private ModeSelectUIManager msUI;
    [SerializeField] private ModeSelectPlayerActionManager msPA;

    // モードセレクトシーンでの動作
    public void ModeSelectAction() {

        msUI.ModeSelectUI();
        msPA.ModeSelectPlayerAction();
    }
}
