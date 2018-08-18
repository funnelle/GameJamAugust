using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    Renderer rend;
    bool expanded;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        expanded = true;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void expand()
    {
        if (expanded)
            return;
        expanded = true;
        rend.enabled = true;

    }
    void collapse()
    {
        if (!expanded)
            return;
      
        rend.enabled = false;
        rend.enabled = false;

    }

}
