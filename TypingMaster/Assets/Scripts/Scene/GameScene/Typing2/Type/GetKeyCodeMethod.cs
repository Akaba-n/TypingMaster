using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キーコードへの変換を行うメソッドクラス
/// </summary>
public class GetKeyCodeMethod : MonoBehaviour{

    /// <summary>
    /// キーコードへの変換を行うメソッド
    /// </summary>
    /// <param name="c">入力キー</param>
    /// <returns>変換されたキーコード</returns>
    public KeyCode GetKeycode(char c) {

        if ('.' == c) {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Period");
        }
        else if (',' == c) {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Comma");
        }
        else if ('-' == c) {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Minus");
        }
        else if ('0' - '0' <= c - '0' && c - '0' <= '9' - '0') {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + c.ToString());
        }
        else if ('a' - 'a' <= c - 'a' && c - 'a' <= 'z' - 'a') {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString().ToUpper());
        }
        return KeyCode.None;
    }
}
