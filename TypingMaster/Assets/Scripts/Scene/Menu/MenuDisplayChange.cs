using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplayChange : MonoBehaviour {
    
    // スクリプトの取得(Inspectorで取得)
    [SerializeField] private MenuMain mm;
    // オブジェクトの取得(Inspectorで取得)
    [SerializeField] private GameObject modeSelect;
    [SerializeField] private GameObject multiModeSelect;
    [SerializeField] private GameObject hostSelect;

    /// <summary>
    /// MenuScene内での画面遷移時の処理
    /// </summary>
    public void MenuMainChange() {

        if (!mm.isChanged) {

            switch (mm.mState) {

                case MenuMain.MENU_STATE.MODE_SELECT:
                    modeSelect.SetActive(true);
                    multiModeSelect.SetActive(false);
                    hostSelect.SetActive(false);
                    break;

                case MenuMain.MENU_STATE.MULTI_MODE_SELECT:
                    modeSelect.SetActive(false);
                    multiModeSelect.SetActive(true);
                    hostSelect.SetActive(false);
                    break;

                case MenuMain.MENU_STATE.MULTI_HOST_SELECT:
                    modeSelect.SetActive(false);
                    multiModeSelect.SetActive(false);
                    hostSelect.SetActive(true);
                    break;

                default:
                    break;
            }
        }
        mm.isChanged = true;
    }
}
