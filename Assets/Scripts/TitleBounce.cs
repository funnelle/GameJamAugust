using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBounce : MonoBehaviour {
    public Image titleImage;

    public float speed;
    public float maxRotation;
    public float maxZoom;
	
	// Update is called once per frame
	void Update () {
        titleImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
        titleImage.rectTransform.localScale = new Vector3(maxZoom * Mathf.Sin(Time.time * speed), maxZoom * Mathf.Sin(Time.time * speed), 0f);
	}
}
