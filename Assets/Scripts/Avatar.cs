using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Avatar : MonoBehaviour {
    
    bool expanded;
    public Button avatarButton; 
    public Canvas bubble;

	// Use this for initialization
	void Start () {
        
        avatarButton.onClick.AddListener(OnClick);
        expanded = true;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnClick()
    {
        if (expanded)
            collapse();
        else
            expand();
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void expand()
    {
        expanded = true;
        bubble.enabled = true;
    }
    void collapse()
    {
        expanded = false;
        bubble.enabled = false;

    }

}
