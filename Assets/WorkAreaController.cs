using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkAreaController : MonoBehaviour {
    public int DataCollectedCount = 0;

    public void IncreaseDataCollected() {
        DataCollectedCount++;
    }
}
