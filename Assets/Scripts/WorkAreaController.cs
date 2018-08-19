using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkAreaController : MonoBehaviour {
    public Button DataMineButton;
    public Button DeployAdButton;
    public Button MonetizeButton;
    public Button GigWorkersButton;
    public Button AutomateButton;
    public Button AcquihireButton;
    public Button BlockchainButton;
    public Button MixedRealityButton;
    public Button MindUploadingButton;

    public Button AcquisitionsButton;
    public Button ResearchButton;

    public int DataSetsCount;
    public int RevenueCount;
    public int UsersCount;
    public int PentaPointsCount;
    public int WorkersCount;

    private int MonetizationLoops;
    private int WorkersEarned;

    public Text DataSetsText;
    public Text RevenueText;
    public Text UsersText;
    public Text PentaPointsText;
    public Text WorkersText;

    private float time;

    private void Start() {
        DataSetsCount = 0;
        RevenueCount = 500;
        UsersCount = 0;
        PentaPointsCount = 0;
        WorkersCount = 0;
        MonetizationLoops = 0;

        AcquisitionsButton.interactable = false;
        ResearchButton.interactable = false;

        SetCountText();
    }

    void SetCountText() {
        DataSetsText.text = "Data Sets: " + DataSetsCount.ToString();
        RevenueText.text = "Revenue: $" + RevenueCount.ToString();
        UsersText.text = "Users: " + UsersCount.ToString();
        PentaPointsText.text = "Penta-Points: " + PentaPointsCount.ToString();
        WorkersText.text = "Workers: " + WorkersCount.ToString();
    }

    public void Update() {
        if(MonetizationLoops>=3) {
            AcquisitionsButton.interactable = true;
        }
        if(WorkersEarned>=100) {
            ResearchButton.interactable = true;
        }
    }

    public void DataMine() {
        if (UsersCount >= 200) {
            DataSetsCount+=200;
            UsersCount-=200;
            SetCountText();
            StartCoroutine(DisableButton(DataMineButton, 17f));
        }
    }

    public void DeployAd() {
        if (RevenueCount >= 500) {
            RevenueCount -= 500;
            UsersCount += 500;
            SetCountText();
            StartCoroutine(DisableButton(DeployAdButton, 15f));
        }
    }

    public void Monetize() {
        if (DataSetsCount>=150) {
            DataSetsCount-=150;
            RevenueCount += 1500;
            MonetizationLoops += 1;
            SetCountText();
            StartCoroutine(DisableButton(MonetizeButton, 20f));
        }
    }

    public void GigWorkers() {
        if (RevenueCount>=1000) {
            RevenueCount -= 1000;
            WorkersCount += 5;
            WorkersEarned += 5;
            SetCountText();
            StartCoroutine(DisableButton(GigWorkersButton, 25f));
        }
    }

    public void Automate() {
        if ((DataSetsCount>=250) && (WorkersCount>=10)) {
            DataSetsCount -= 250;
            WorkersCount -= 10;
            RevenueCount += 2500;
            SetCountText();
            StartCoroutine(DisableButton(AutomateButton, 25f));
        }
    }

    public void Acquihire() {
        if (RevenueCount>=3000) {
            RevenueCount -= 3000;
            UsersCount += 1200;
            WorkersCount += 12;
            WorkersEarned += 12;
            SetCountText();
            StartCoroutine(DisableButton(AcquihireButton, 30f));
        }
    }

    public void Blockchain() {
        Debug.Log("Using blockchain");
        RevenueCount += Random.Range(-12000, 12000);
        SetCountText();
        StartCoroutine(DisableButton(BlockchainButton, 30f));
    }

    public void MixedReality() {
        if (RevenueCount>=5000) {
            RevenueCount -= 5000;
            UsersCount += 2500;
            SetCountText();
            StartCoroutine(DisableButton(MixedRealityButton, 20f));
        }
    }

    public void MindUploading() {
        if ((UsersCount >= 3000) && (WorkersCount>=30)) {
            UsersCount -= 3000;
            WorkersCount -= 30;
            DataSetsCount += 3030;
            PentaPointsCount += 50;
            SetCountText();
            StartCoroutine(DisableButton(MindUploadingButton, 30f));
        }
    }

    private IEnumerator DisableButton(Button buttonName, float disableButtonTime) {
        buttonName.interactable = false;
        yield return new WaitForSeconds(disableButtonTime);
        buttonName.interactable = true;
    }

}
