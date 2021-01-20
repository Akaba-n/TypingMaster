using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiMistakeMethod : MonoBehaviour {

    [SerializeField] private MultiPlayerActionManager pa;

    /// <summary>
    /// ミスタイプ時の処理
    /// </summary>
    public void Mistake()
    {

        // ミスタイプ数を増やす
        pa.MisTypeNum++;
        // ミスタイプ判定
        pa.isRecMistype = true;
    }
}
