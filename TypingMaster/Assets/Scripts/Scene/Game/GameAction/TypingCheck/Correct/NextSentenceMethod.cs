using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSentenceMethod : MonoBehaviour {

    [SerializeField] private GameActionManager ga;
    
    public void NextSentence() {

        ga.index = 0;
        
    }
}
