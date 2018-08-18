using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkAreaController : MonoBehaviour {
    public int DataSetsCount;
    public int NewFollowersCount;
    public int RevenueCount;
    public int UsersCount;
    public int PentaPointsCount;

    public Text DataSetsText;
    public Text NewFollowersText;
    public Text RevenueText;
    public Text UsersText;
    public Text PentaPointsText;

    private void Start() {
        DataSetsCount = 0;
        NewFollowersCount = 0;
        RevenueCount = 500;
        UsersCount = 0;
        PentaPointsCount = 0;
        SetCountText();
    }

    void SetCountText() {
        DataSetsText.text = "Data Sets: " + DataSetsCount.ToString();
        NewFollowersText.text = "New Followers: " + NewFollowersCount.ToString();
        RevenueText.text = "Revenue: $" + RevenueCount.ToString();
        UsersText.text = "Users: " + UsersCount.ToString();
        PentaPointsText.text = "Penta-Points: " + PentaPointsCount.ToString();
    }

    public void DataMine() {
        if (NewFollowersCount >= 1) {
            DataSetsCount++;
            NewFollowersCount--;
            UsersCount++;
            SetCountText();
        }
    }

    public void DeployAd() {
        if (RevenueCount >= 500) {
            RevenueCount = RevenueCount - 500;
            NewFollowersCount++;
            SetCountText();
        }
    }

    public void SellData() {
        if (DataSetsCount>=1) {
            DataSetsCount--;
            RevenueCount = RevenueCount + 500;
            SetCountText();
        }
    }
}
