using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Image timerImage;
    public Button buttonName;
    public float totalTime;

    float time;

	// Use this for initialization
	void Start () {
        time = totalTime;
        timerImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonName.interactable == false) {
            timerImage.enabled = true;
            time -= Time.deltaTime;
            timerImage.fillAmount = time / totalTime;
        }
        else {
            time = totalTime;
            timerImage.enabled = false;
        }
	}
}
