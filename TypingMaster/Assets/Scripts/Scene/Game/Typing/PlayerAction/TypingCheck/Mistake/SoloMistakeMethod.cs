using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ミスタイプ時の処理クラス
/// </summary>
public class SoloMistakeMethod : MonoBehaviour {

    [SerializeField] private SoloPlayerActionManager pa;

    /// <summary>
    /// ミスタイプ時の処理
    /// </summary>
    public void Mistake() {

        // ミスタイプ数を増やす
        pa.MisTypeNum++;
        // ミスタイプ判定
        pa.isRecMistype = true;
    }
}
