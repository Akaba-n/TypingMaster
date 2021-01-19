using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class InitSoloQuestionMethod : MonoBehaviour {

    [SerializeField] private GameConfigClass gc;
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private CsvImport ci;
    [SerializeField] private HiraToRom hr;
    
    /// <summary>
    /// Soloモードでの問題文初期化処理
    /// </summary>
    public void InitSoloQuestion() {

        // 問題データセットの取得
        var qJP = ci.datasetImport(gc.gc.DatasetName);
        // 選択済み判定(問題順並び替え用)
        var pickList = new bool[qJP.Count];

        for(var i = 0; i < gc.gc.Tasks; i++) {

            // 問題文の順序入れ替え + ローマ字入力候補追加
            var tempNum = UnityEngine.Random.Range(0, qJP.Count);
            // 被ってなかったら追加
            if (!pickList[tempNum]) {

                pa.qSen.Add((qJP[tempNum].jp, qJP[tempNum].h, hr.HiraToRomSentence(qJP[tempNum].h)));
                pickList[tempNum] = true;
            }
            else {

                i -= 1;
            }
        }
    }
}
