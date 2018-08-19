using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsController : MonoBehaviour {

    Time time;
    public GameObject avatarPrefab;
    List<Avatar> scripts = new List<Avatar>();

    void Start () {
        int top = 140;
        int right = 205;
        this.newAvatar(new Vector3(right, top + 0F, 0), "Cliff Pittman");
        this.newAvatar(new Vector3(right, top + -50F, 0), "Diana Brown");
        this.newAvatar(new Vector3(right, top + -100F, 0), "Benton Solomon (CEO/Thought Leader)");
        this.newAvatar(new Vector3(right, top + -150F, 0), "Parker Livingston");
        this.newAvatar(new Vector3(right, top + -200F, 0), "Ariana Cole");
        this.newAvatar(new Vector3(right, top + -250F, 0), "Sage Williams (HR)");
        this.newAvatar(new Vector3(right, top + -300F, 0), "News");

        foreach (Transform child in transform)
        {
            scripts.Add(child.GetComponent<Avatar>());
        }
    }


    public void newAvatar(Vector3 possition, string name)
    {
        GameObject newAvatar = Instantiate(avatarPrefab);
        newAvatar.name = name;
        newAvatar.transform.SetParent(this.transform);
        RectTransform bossTranform = newAvatar.GetComponent<RectTransform>();
        bossTranform.position += possition;
        bossTranform.localScale += new Vector3(-0.8F, -0.8F, 0);
        newAvatar.GetComponent<Avatar>().setName(name);
    }


    // Update is called once per frame
    void Update () {

        foreach (Avatar child in scripts)
        {
            switch(child.getName())
            {
                case "Cliff Pittman":
                    handleCliff(child);
                    break;
                case "Diana Brown":
                    handleDiana(child);
                    break;
                case "Benton Solomon (CEO/Thought Leader)":
                    handleBenton(child);
                    break;
                case "Parker Livingston":
                    handleParker(child);
                    break;
                case "Ariana Cole":
                    handleAriana(child);
                    break;
                case "Sage Williams (HR)":
                    handleSage(child);
                    break;
                case "News":
                    handleNews(child);
                    break;
            }
        }
    }

    private void handleNews(Avatar child)
    {
        child.notify("stuff");
    }

    private void handleSage(Avatar child)
    {
        child.notify("stuff");
    }

    private void handleAriana(Avatar child)
    {
    }

    private void handleParker(Avatar child)
    {
    }

    private void handleBenton(Avatar child)
    {
    }

    private void handleDiana(Avatar child)
    {
    }

    private void handleCliff(Avatar child)
    {
        child.notify("stuff");
    }
}
