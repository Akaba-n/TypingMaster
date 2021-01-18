using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CountDown画面での処理管理クラス
/// </summary>
public class SoloCountDownManager : MonoBehaviour {

    [SerializeField] private SoloCountDownUIManager scdUI;

    // 秒数
    public double countSec;

    private void Start() {

        countSec = 3.999f;
    }

    /// <summary>
    /// CountDown画面での処理
    /// </summary>
    public void CountDown() {

        countSec -= Time.deltaTime;
        scdUI.SoloCountDownUI();
    }
}
