using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 問題文のデータセット
/// </summary>
public class SentenceDataClass : MonoBehaviour {

    [SerializeField] private GameConfigClass gc;

    public class SentenceData {

        public string jp;   // 日本語文
        public string h;    // ひらがな文
        public string[] rm; // ローマ字入力候補
    }

    public SentenceData[] sd;

    private void Start() {

        // 問題数分の配列作成
        sd = new SentenceData[gc.gc.Tasks];
    }
}
