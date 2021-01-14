using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // これはメモリ管理の観点から見ると重いらしい...?

public class HiraToRom {

    // 平仮名->ローマ字マッピングのDictionary
    private Dictionary<string, string[]> mp = new Dictionary<string, string[]> {
        {"あ", new string[1] {"a"}},
        {"い", new string[2] {"i", "yi"}},
        {"う", new string[3] {"u", "wu", "whu"}},
        {"え", new string[1] {"e"}},
        {"お", new string[1] {"o"}},
        {"か", new string[2] {"ka", "ca"}},
        {"き", new string[1] {"ki"}},
        {"く", new string[3] {"ku", "cu", "qu"}},
        {"け", new string[1] {"ke"}},
        {"こ", new string[2] {"ko", "co"}},
        {"さ", new string[1] {"sa"}},
        {"し", new string[3] {"si", "shi", "ci"}},
        {"す", new string[1] {"su"}},
        {"せ", new string[2] {"se", "ce"}},
        {"そ", new string[1] {"so"}},
        {"た", new string[1] {"ta"}},
        {"ち", new string[2] {"ti", "chi"}},
        {"つ", new string[2] {"tu", "tsu"}},
        {"て", new string[1] {"te"}},
        {"と", new string[1] {"to"}},
        {"な", new string[1] {"na"}},
        {"に", new string[1] {"ni"}},
        {"ぬ", new string[1] {"nu"}},
        {"ね", new string[1] {"ne"}},
        {"の", new string[1] {"no"}},
        {"は", new string[1] {"ha"}},
        {"ひ", new string[1] {"hi"}},
        {"ふ", new string[2] {"hu", "fu"}},
        {"へ", new string[1] {"he"}},
        {"ほ", new string[1] {"ho"}},
        {"ま", new string[1] {"ma"}},
        {"み", new string[1] {"mi"}},
        {"む", new string[1] {"mu"}},
        {"め", new string[1] {"me"}},
        {"も", new string[1] {"mo"}},
        {"や", new string[1] {"ya"}},
        {"ゆ", new string[1] {"yu"}},
        {"よ", new string[1] {"yo"}},
        {"ら", new string[1] {"ra"}},
        {"り", new string[1] {"ri"}},
        {"る", new string[1] {"ru"}},
        {"れ", new string[1] {"re"}},
        {"ろ", new string[1] {"ro"}},
        {"わ", new string[1] {"wa"}},
        {"を", new string[1] {"wo"}},
        {"ん", new string[3] {"n", "nn", "xn"}},
        {"が", new string[1] {"ga"}},
        {"ぎ", new string[1] {"gi"}},
        {"ぐ", new string[1] {"gu"}},
        {"げ", new string[1] {"ge"}},
        {"ご", new string[1] {"go"}},
        {"ざ", new string[1] {"za"}},
        {"じ", new string[2] {"zi", "ji"}},
        {"ず", new string[1] {"zu"}},
        {"ぜ", new string[1] {"ze"}},
        {"ぞ", new string[1] {"zo"}},
        {"だ", new string[1] {"da"}},
        {"ぢ", new string[1] {"di"}},
        {"づ", new string[1] {"du"}},
        {"で", new string[1] {"de"}},
        {"ど", new string[1] {"do"}},
        {"ば", new string[1] {"ba"}},
        {"び", new string[1] {"bi"}},
        {"ぶ", new string[1] {"bu"}},
        {"べ", new string[1] {"be"}},
        {"ぼ", new string[1] {"bo"}},
        {"ぱ", new string[1] {"pa"}},
        {"ぴ", new string[1] {"pi"}},
        {"ぷ", new string[1] {"pu"}},
        {"ぺ", new string[1] {"pe"}},
        {"ぽ", new string[1] {"po"}},
        {"ぁ", new string[2] {"la", "xa"}},
        {"ぃ", new string[4] {"li", "xi", "lyi", "xyi"}},
        {"ぅ", new string[2] {"lu", "xu"}},
        {"ぇ", new string[4] {"le", "xe", "lye", "xye"}},
        {"ぉ", new string[2] {"lo", "xo"}},
        {"ゃ", new string[2] {"lya", "xya"}},
        {"ゅ", new string[2] {"lyu", "xyu"}},
        {"ょ", new string[2] {"lyo", "xyo"}},
        {"っ", new string[4] {"ltu", "ltsu", "xtu", "xtsu"}},
        {"うぁ", new string[1] {"wha"}},
        {"うぃ", new string[2] {"wi", "whi"}},
        {"うぇ", new string[2] {"we", "whe"}},
        {"うぉ", new string[1] {"who"}},
        {"きゃ", new string[1] {"kya"}},
        {"きぃ", new string[1] {"kyi"}},
        {"きゅ", new string[1] {"kyu"}},
        {"きぇ", new string[1] {"kye"}},
        {"きょ", new string[1] {"kyo"}},
        {"ぎゃ", new string[1] {"gya"}},
        {"ぎぃ", new string[1] {"gyi"}},
        {"ぎゅ", new string[1] {"gyu"}},
        {"ぎぇ", new string[1] {"gye"}},
        {"ぎょ", new string[1] {"gyo"}},
        {"くぁ", new string[2] {"qa", "kwa"}},
        {"くぃ", new string[2] {"qi", "qyi"}},
        {"くぅ", new string[1] {"qwu"}},
        {"くぇ", new string[3] {"qe", "qye", "qwe"}},
        {"くぉ", new string[2] {"qo", "qwo"}},
        {"ぐぁ", new string[1] {"gwa"}},
        {"ぐぃ", new string[1] {"gwi"}},
        {"ぐぅ", new string[1] {"gwu"}},
        {"ぐぇ", new string[1] {"gwe"}},
        {"ぐぉ", new string[1] {"gwo"}},
        {"しゃ", new string[2] {"sya", "sha"}},
        {"しぃ", new string[1] {"syi"}},
        {"しゅ", new string[2] {"syu", "shu"}},
        {"しぇ", new string[2] {"sye", "she"}},
        {"しょ", new string[2] {"syo", "sho"}},
        {"じゃ", new string[3] {"ja", "jya", "zya"}},
        {"じぃ", new string[2] {"jyi", "zyi"}},
        {"じゅ", new string[3] {"ju", "zyu", "jyu"}},
        {"じぇ", new string[2] {"jye", "zye"}},
        {"じょ", new string[3] {"jo", "zyo", "jyo"}},
        {"すぁ", new string[1] {"swa"}},
        {"すぃ", new string[1] {"swi"}},
        {"すぅ", new string[1] {"swu"}},
        {"すぇ", new string[1] {"swe"}},
        {"すぉ", new string[1] {"swo"}},
        {"ちゃ", new string[3] {"tya", "cya", "cha"}},
        {"ちぃ", new string[2] {"tyi", "cyi"}},
        {"ちゅ", new string[3] {"tyu", "cyu", "chu"}},
        {"ちぇ", new string[3] {"tye", "cye", "che"}},
        {"ちょ", new string[3] {"tyo", "cyo", "cho"}},
        {"ぢゃ", new string[1] {"dya"}},
        {"ぢぃ", new string[1] {"dyi"}},
        {"ぢゅ", new string[1] {"dyu"}},
        {"ぢぇ", new string[1] {"dye"}},
        {"ぢょ", new string[1] {"dyo"}},
        {"てゃ", new string[1] {"tha"}},
        {"てぃ", new string[1] {"thi"}},
        {"てゅ", new string[1] {"thu"}},
        {"てぇ", new string[1] {"the"}},
        {"てょ", new string[1] {"tho"}},
        {"でゃ", new string[1] {"dha"}},
        {"でぃ", new string[1] {"dhi"}},
        {"でゅ", new string[1] {"dhu"}},
        {"でぇ", new string[1] {"dhe"}},
        {"でょ", new string[1] {"dho"}},
        {"とぁ", new string[1] {"twa"}},
        {"とぃ", new string[1] {"twi"}},
        {"とぅ", new string[1] {"twu"}},
        {"とぇ", new string[1] {"twe"}},
        {"とぉ", new string[1] {"two"}},
        {"どぁ", new string[1] {"dwa"}},
        {"どぃ", new string[1] {"dwi"}},
        {"どぅ", new string[1] {"dwu"}},
        {"どぇ", new string[1] {"dwe"}},
        {"どぉ", new string[1] {"dwo"}},
        {"にゃ", new string[1] {"nya"}},
        {"にぃ", new string[1] {"nyi"}},
        {"にゅ", new string[1] {"nyu"}},
        {"にぇ", new string[1] {"nye"}},
        {"にょ", new string[1] {"nyo"}},
        {"ひゃ", new string[1] {"hya"}},
        {"ひぃ", new string[1] {"hyi"}},
        {"ひゅ", new string[1] {"hyu"}},
        {"ひぇ", new string[1] {"hye"}},
        {"ひょ", new string[1] {"hyo"}},
        {"びゃ", new string[1] {"bya"}},
        {"びぃ", new string[1] {"byi"}},
        {"びゅ", new string[1] {"byu"}},
        {"びぇ", new string[1] {"bye"}},
        {"びょ", new string[1] {"byo"}},
        {"ぴゃ", new string[1] {"pya"}},
        {"ぴぃ", new string[1] {"pyi"}},
        {"ぴゅ", new string[1] {"pyu"}},
        {"ぴぇ", new string[1] {"pye"}},
        {"ぴょ", new string[1] {"pyo"}},
        {"ふぁ", new string[1] {"fa"}},
        {"ふぃ", new string[2] {"fi", "fyi"}},
        {"ふぇ", new string[2] {"fe", "fye"}},
        {"ふぉ", new string[1] {"fo"}},
        {"ふゃ", new string[1] {"fya"}},
        {"ふゅ", new string[1] {"fyu"}},
        {"ふょ", new string[1] {"fyo"}},
        {"みゃ", new string[1] {"mya"}},
        {"みぃ", new string[1] {"myi"}},
        {"みゅ", new string[1] {"myu"}},
        {"みぇ", new string[1] {"mye"}},
        {"みょ", new string[1] {"myo"}},
        {"りゃ", new string[1] {"rya"}},
        {"りぃ", new string[1] {"ryi"}},
        {"りゅ", new string[1] {"ryu"}},
        {"りぇ", new string[1] {"rye"}},
        {"りょ", new string[1] {"ryo"}},
        {"ヴァ", new string[1] {"va"}},
        {"ヴィ", new string[2] {"vi", "vyi"}},
        {"ヴ", new string[1] {"vu"}},
        {"ヴェ", new string[2] {"ve", "vye"}},
        {"ヴォ", new string[1] {"vo"}},
        {"ヴゃ", new string[1] {"vya"}},
        {"ヴゅ", new string[1] {"vyu"}},
        {"ヴょ", new string[1] {"vyo"}},
        {"ゐ", new string[1] { "wyi"}},
        {"ゑ", new string[1] { "wye"}},
        {"ー", new string[1] {"-"}},
        {"、", new string[1] {","}},
        {"。", new string[1] {"."}},
        {"0", new string[1] {"0"}},
        {"1", new string[1] {"1"}},
        {"2", new string[1] {"2"}},
        {"3", new string[1] {"3"}},
        {"4", new string[1] {"4"}},
        {"5", new string[1] {"5"}},
        {"6", new string[1] {"6"}},
        {"7", new string[1] {"7"}},
        {"8", new string[1] {"8"}},
        {"9", new string[1] {"9"}},
        {"０", new string[1] {"0"}},
        {"１", new string[1] {"1"}},
        {"２", new string[1] {"2"}},
        {"３", new string[1] {"3"}},
        {"４", new string[1] {"4"}},
        {"５", new string[1] {"5"}},
        {"６", new string[1] {"6"}},
        {"７", new string[1] {"7"}},
        {"８", new string[1] {"8"}},
        {"９", new string[1] {"9"}},
        {"-", new string[1] {"-"}},
        {",", new string[1] {","}},
        {".", new string[1] {"."}},
        {";", new string[1] {";"}},
        {":", new string[1] {":"}},
        {"[", new string[1] {"["}},
        {"]", new string[1] {"]"}},
        {"@", new string[1] {"@"}},
        {"/", new string[1] {"/"}},
        {"_", new string[1] {"_"}},
        {"!", new string[1] {"!"}},
        {"！", new string[1] {"!"}},
        {"?", new string[1] {"?"}},
        {"？", new string[1] {"?"}}
    };

    /// <summary>
    /// ひらがな文をローマ字入力候補に変換する関数
    /// </summary>
    /// <param name="h">ひらがな文</param>
    /// <returns>ローマ字入力候補</returns>
    public List<List<string>> HiraToRomSentence(string h) {

        return ConstructTypeSentence(ParseHiraganaSentence(h));
    }

    /// <summary>
    /// ひらがな文を1~2文字に区切る関数
    /// </summary>
    /// <param name="h">ひらがな文</param>
    /// <returns>ひらがな文を区切ったList</returns>
    private List<string> ParseHiraganaSentence(string h) {

        // 返す値の初期化
        var ret = new List<string>();

        int i = 0;
        // uni:1文字格納, bi:2文字格納
        string uni, bi;

        while(i < h.Length) {

            // 1文字取得
            uni = h[i].ToString();
            if(i + 1 < h.Length) {

                // 2文字取得
                bi = h[i].ToString() + h[i + 1].ToString();
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
            if (s.Equals("ん")) {

                bool isSingleN; // nが1つでも良いかの判定

                // "ん"の入力候補格納
                var nList = mp[s];

                // 文末の"ん" -> nn, xnのみ
                if (hList.Count - 1 == i) {

                    isSingleN = false;
                }
                // 後ろに母音、ナ行、ヤ行 -> nn, xnのみ
                else if (i + 1 < hList.Count &&
                (ns.Equals("あ") || ns.Equals("い") || ns.Equals("う") || ns.Equals("え") || ns.Equals("お") ||
                ns.Equals("な") || ns.Equals("に") || ns.Equals("ぬ") || ns.Equals("ね") || ns.Equals("の") ||
                ns.Equals("や") || ns.Equals("ゆ") || ns.Equals("よ"))) {

                    isSingleN = false;
                }
                // それ以外は n も許容
                else {

                    isSingleN = true;
                }

                foreach (var t in nList) {

                    // isSingleNがfalseの時"n"はListに追加しない
                    if (!isSingleN && t.Equals("n")) {

                        continue;
                    }

                    tmpList.Add(t);
                }
            }

            // "っ"の処理
            /*** もしかしたら"っん"みたいな文字列で"nnn"が許容されてしまうかも ***/
            else if (s.Equals("っ")) {

                // "っ"の入力候補格納
                var ltuList = mp[s];
                // "っ"の次の文字の入力候補格納
                var nexrList = mp[ns];
                var hs = new HashSet<string>();

                // 次の文字の子音だけ取ってくる
                foreach (string t in nexrList) {

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
