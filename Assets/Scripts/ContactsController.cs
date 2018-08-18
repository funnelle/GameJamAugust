using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsController : MonoBehaviour {

    Time time;
    List<Avatar> scripts = new List<Avatar>();
	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            scripts.Add(child.GetComponent<Avatar>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        /*
        foreach (Avatar child in scripts)
        {
            Debug.Log(child.getName());
            //scripts.Add(child.GetComponent<Avatar>());
        }
        */
    }
}
