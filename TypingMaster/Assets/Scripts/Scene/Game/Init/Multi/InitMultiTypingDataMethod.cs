using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMultiTypingDataMethod : MonoBehaviour {
    
    [SerializeField] private MultiPlayerTypingDataManager ptd;
    [SerializeField] private GameConfigClass gc;
    
    public void InitTypingData() {

        ptd.td.CorrectTypeNum = 0;
        ptd.td.CorrectTaskNum = 0;
        ptd.td.MisTypeNum = 0;
        ptd.td.TotalTypingTime = 0f;
        ptd.td.Kpm = 0f;
        ptd.td.Accuracy = 0f;
        ptd.MisTypeDictionary = new Dictionary<string, int>();
        ptd.SectionTypingTime = new double[gc.gc.Tasks];
        ptd.SectionCorrectNum = new int[gc.gc.Tasks];
        ptd.SectionKpm = new double[gc.gc.Tasks];
        ptd.td.retrySelect = 0;
    }
}
