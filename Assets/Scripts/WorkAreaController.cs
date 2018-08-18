using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkAreaController : MonoBehaviour {
    public int DataCollectedCount;
    public Text DataCollectedText;

    private void Start() {
        DataCollectedCount = 0;
        SetCountText();
    }

    public void IncreaseDataCollected() {
        DataCollectedCount++;
        SetCountText();
    }

    void SetCountText() {
        DataCollectedText.text = "Data Collected: " + DataCollectedCount.ToString();
    }
}
