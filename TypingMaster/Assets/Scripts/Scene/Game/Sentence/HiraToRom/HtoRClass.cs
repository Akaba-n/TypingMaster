//using System;
//using System.IO;
using System.Linq;
//using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;

/// <summary>
/// ひらがな文をローマ字文に変換する用のクラス
/// </summary>
public class HtoRClass : MonoBehaviour {

    // ひらがな→ローマ字Map呼び出し
    private Dictionary<string, string[]> mp = HtoRMap.HR_MAP;

    /// <summary>
    /// ひらがな文をローマ字に変換するメソッド
    /// </summary>
    /// <param name="hSen">ひらがな文</param>
    /// <returns>ローマ字入力候補</returns>
    public List<List<string>> HtoRSentence(string hSen) {

        return ConstructTypeSentence(ParseHiraganaSentence(hSen));
    }

    /// <summary>
    /// ひらがな文を1~2文字に区切る関数
    /// </summary>
    /// <param name="str">ひらがな文</param>
    /// <returns>ひらがな文を区切ったList</returns>
    private List<string> ParseHiraganaSentence(string hSen) {

        // 返す値の初期化
        var ret = new List<string>();

        int i = 0;
        // uni:1文字格納, bi:2文字格納
        string uni, bi;

        while(i < hSen.Length) {

            // 1文字取得
            uni = hSen[i].ToString();
            if(i + 1 < hSen.Length) {

                // 2文字取得
                bi = hSen[i].ToString() + hSen[i + 1].ToString();
            }
            else {

                // 取得できない時は空に
                bi = "";
            }

            // 上で定義したひらがな->ローマ字マッピングを参照して
            // 2文字->1文字の順番で一致しているかを確認
            if (mp.ContainsKey(bi)) {

                i += 2;
                ret.Add(bi);
            }
            else {

                i += 1;
                ret.Add(uni);
            }
        }

        return ret;
    }

    /// <summary>
    /// 1~2文字に区切ったひらがな文からローマ字入力候補に変換するメソッド
    /// </summary>
    /// <param name="hList">1~2文字に区切ったひらがな文</param>
    /// <returns>ローマ字入力候補List</returns>
    private List<List<string>> ConstructTypeSentence(List<string> hList) {

        // 返す値の初期化
        var ret = new List<List<string>>();

        // s:Listのi枠目, ns:i+1枠目
        string s, ns;

        for(int i = 0; i < hList.Count; ++i) {

            // i枠目を取得
            s = hList[i];
            if(i + 1 < hList.Count) {

                // i+1枠目を取得
                ns = hList[i + 1];
            }
            else {

                // 取得出来ない場合は空にする
                ns = "";
            }

            // 1文字分変換結果List作成
            var tmpList = new List<string>();

            ///// 例外処理 /////
            // "ん"の処理
            if (s.Equals("ん"))
            {

                bool isSingleN; // nが1つでも良いかの判定

                // "ん"の入力候補格納
                var nList = mp[s];

                // 文末の"ん" -> nn, xnのみ
                if (hList.Count - 1 == i)
                {

                    isSingleN = false;
                }
                // 後ろに母音、ナ行、ヤ行 -> nn, xnのみ
                else if (i + 1 < hList.Count &&
                (ns.Equals("あ") || ns.Equals("い") || ns.Equals("う") || ns.Equals("え") || ns.Equals("お") ||
                ns.Equals("な") || ns.Equals("に") || ns.Equals("ぬ") || ns.Equals("ね") || ns.Equals("の") ||
                ns.Equals("や") || ns.Equals("ゆ") || ns.Equals("よ")))
                {

                    isSingleN = false;
                }
                // それ以外は n も許容
                else
                {

                    isSingleN = true;
                }

                foreach (var t in nList)
                {

                    // isSingleNがfalseの時"n"はListに追加しない
                    if (!isSingleN && t.Equals("n"))
                    {

                        continue;
                    }

                    tmpList.Add(t);
                }
            }

            // "っ"の処理
            /*** もしかしたら"っん"みたいな文字列で"nnn"が許容されてしまうかも ***/
            else if (s.Equals("っ"))
            {

                // "っ"の入力候補格納
                var ltuList = mp[s];
                // "っ"の次の文字の入力候補格納
                var nexrList = mp[ns];
                var hs = new HashSet<string>();

                // 次の文字の子音だけ取ってくる
                foreach (string t in nexrList)
                {

                    string c = t[0].ToString();
                    hs.Add(c);
                }

                var hsList = hs.ToList();
                // "っ"の候補の追加
                // Concat: Listの結合
                List<string> ltuTypeList = hsList.Concat(ltuList).ToList();
                tmpList = ltuTypeList;
            }

            // "ちゃ"等のように"tya", "cha" や ち + ゃ を許容するパターン
            else if (s.Length == 2 && !string.Equals("ん", s[0])) {

                // "ちゃ" 等そのまま打つパターンの生成
                tmpList = tmpList.Concat(mp[s]).ToList();
                // "ち" + "ゃ" 等分解して入力するパターンの生成
                var fstList = mp[s[0].ToString()];  // 1文字目のリスト
                var sndList = mp[s[1].ToString()];  // 2文字目のリスト
                var retList = new List<string>();

                foreach(string fstStr in fstList) {

                    foreach(string sndStr in sndList) {

                        string t = fstStr + sndStr;
                        retList.Add(t);
                    }
                }

                tmpList = tmpList.Concat(retList).ToList();
            }

            // それ以外
            else {

                tmpList = mp[s].ToList();
            }

            // 返す値に追加
            ret.Add(tmpList);
        }

        return ret;
    }
}
