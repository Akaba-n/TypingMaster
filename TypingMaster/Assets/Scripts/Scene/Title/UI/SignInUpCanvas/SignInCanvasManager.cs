using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInCanvasManager : MonoBehaviour {
    
    // SignInとSignUpのどちらの処理中かの判定
    public enum SIGN_STATE {

        SIGN_IN,
        SIGN_UP
    };
    public SIGN_STATE sState;
    // 現在アクティブなフィールドの判定
    public enum ACTIVE_FIELD {

        MAIL_FIELD,
        NAME_FIELD,
        SUBMIT_BUTTON,
        CHANGE_IN_UP,
        NONE
    }
    public ACTIVE_FIELD actField = ACTIVE_FIELD.NONE;
}
