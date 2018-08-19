using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsController : MonoBehaviour {

    Time time;
    public GameObject avatarPrefab;
    List<Avatar> scripts = new List<Avatar>();
	// Use this for initialization
	void Start () {
        GameObject boss2 = Instantiate(avatarPrefab);
        boss2.transform.SetParent(this.transform);
        //boss2.transform.position()

        //boss2.parent = this;

        //boss2.
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
