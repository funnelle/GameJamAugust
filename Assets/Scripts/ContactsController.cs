using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsController : MonoBehaviour {

    float startTime;
    public GameObject avatarPrefab;
    List<Avatar> scripts = new List<Avatar>();
    public GameObject workController;
    private WorkAreaController values;
    private float eventNounce = 0;


    void Start () {

        startTime = Time.time;
        int top = -20;
        int right = 0;
        int interval = -90;
        this.newAvatar(new Vector3(right, top + interval, 0), "Cliff Pittman");
        this.newAvatar(new Vector3(right, top + interval * 2, 0), "Diana Brown");
        this.newAvatar(new Vector3(right, top + interval * 3, 0), "Benton Solomon (CEO/Thought Leader)");
        this.newAvatar(new Vector3(right, top + interval * 4, 0), "Parker Livingston");
        this.newAvatar(new Vector3(right, top + interval * 5, 0), "Ariana Cole");
        this.newAvatar(new Vector3(right, top + interval * 6, 0), "Sage Williams (HR)");
        this.newAvatar(new Vector3(right, top + interval * 7, 0), "News");

        values = workController.GetComponent<WorkAreaController>();
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
        Debug.Log(this.transform.position);
        RectTransform bossTranform = newAvatar.GetComponent<RectTransform>();
        bossTranform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        bossTranform.position += possition;
        bossTranform.localScale += new Vector3(-0.1F, -0.1F, 0);

        newAvatar.GetComponent<Avatar>().setName(name);
    }


    // Update is called once per frame
    void Update () {

        int data = values.DataSetsCount;
        int revenue = values.RevenueCount;
        int users = values.UsersCount;
        int penta = values.PentaPointsCount;
        int workers = values.WorkersCount;
   
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

    private void handleNews(Avatar contact)
    {
        if (Time.time < 1F)
        {
            contact.notify("PentaCo Enters Social Media Arena with BONDr", 1);
        }
        
    }

    private void handleSage(Avatar contact)
    {

        if (Time.time > 120F)
        {
            contact.notify("Enterprise unity is very important to us here at PentaCo. Please remember to share your BONDr account with your office team mates.", 1);
        }
    }

    private void handleAriana(Avatar contact)
    {
        if (values.WorkersCount > 19)
        {
            contact.notify("Hey office buddy! A few of us are going for karaoke later. You should come! :D", 1);
            contact.respond("Sounds fun!", "As if.", new int[] { 0, 0, 0, -10, 0 }, new int[] { 0, 0, 0, 10, 0 }, 2);
        }
        if (values.WorkersCount > 99)
        {
            contact.notify("It looks like they like what you’re doing here at PentaCo. Just… Don’t get in over your head. And congratulations.", 3);
        }
    }

    private void handleParker(Avatar contact)
    {
        if ( 2F < Time.time  && Time.time < 5F)  
        {
             contact.notify("Welcome to the team! :) I think we’re gogna have fun together.", 1);
        }
        if (5F < Time.time && Time.time < 7F)
        {
             contact.notify("Welcome to the team! :) I think we’re gonna have fun together. (edited)", 2);
        }
        if (870F < Time.time)
        {
            contact.notify("Something really terrible is going on. This company is not what it seems. I’m being called to HR now. I hope I’m wrong about this", 3);
        }
        if (873F < Time.time)
        {
            contact.notify(" (edited)", 4);
        }

        if (90F < Time.time)
        {
            contact.notify("Me and my desk mate Vanessa are going out tonight.You should come, too!", 5);
        }

        //fourth monitize action
        if (4000 < values.RevenueCount)
        {
            contact.notify("Look at you, big shot!Don’t forget about us little people, haha.Coffee later ?", 6);
            contact.respond("You know it!", "Another time.", new int[] { 0, 0, 0, -5, 0 }, new int[] { 0, 0, 0, 5, 0 }, 7);
        }




    }

    private void handleBenton(Avatar contact)
    {
        if (30F < Time.time)
        {
           contact.notify("This is a reminder for all employees that the ritual is less than five months away.It is mission critical that we reach our goal of X data sets.", 1);
        }
        if (32F < Time.time)
        {
            contact.notify("This is a reminder for all employees that our shareholder meeting is less than five months away. It is mission critical that we reach our goal of X data sets. (edited)", 2);
        }
        if (240F < Time.time)
        {
            contact.notify("This is a reminder that our shareholder meeting is four months away. If we do not reach our goal of X data sets by then, they will not be pleased.", 3);
        }
        if (420 < Time.time)
        {
            contact.notify("This is a reminder for all employees that our shareholder meeting is three months away. Please aim to exceed our target of X data sets, so that we may all be rewarded.", 4);
        }   
        if (780 < Time.time)
        {
            contact.notify("This is a reminder for all employees that our shareholder meeting is one month from now. Reaching our goal of X data sets by the deadline is of utmost importance, and any employees not carrying their weight in this regard will be discarded", 5);
        }
        if (values.WorkersCount > 99)
        {
            contact.notify("As our new Senior Loved Ones Unification Manager, the success of the company must be your number one priority", 6);
        }
        //asdfasdf
        /*
        if ()
        {
            contact.notify("The government is preparing a privacy rights bill that could be less than ideal. I need you to arrange for a lobby group to influence the legislation in our favour. Responses: “We won’t let the bill pass.", 7);
            contact.respond("We wont let this bill pass!", "I won’t interfere with the process.", new int[] { 0, 2000, 150, 25, 0 }, new int[] { 0, -1500, -150, -25, 0 }, 8);
        }
        */

    }

    private void handleDiana(Avatar contact)
    {
        if (values.RevenueCount > 3000)
        {
            contact.notify("Welcome to the world of Family Acquisitions Facilitators. Stay a while.", 1);
        }
    }

    private void handleCliff(Avatar contact)
    {
        if (values.DataSetsCount == 200 )
        {
            contact.notify("Growth Hacker isn’t the most glamorous position, but you start bringing in revenue and I’ll see what I can do.", 1);
        }
        if (values.RevenueCount > 500)
        {
            contact.notify("What do you think about using more memes in our ads? The kids like those, right? And we can get our name out faster with less work.", 2);
            contact.respond("Sounds Good!", "Let's not", new int[] {0,0,20,25,0}, new int[] { 0, 0, 0, -5, 0 }, 3);
        }
        if (values.RevenueCount > 3000)
        {
            contact.notify("Good job, kid. You’re moving up.", 4);
        }



        
    }
}

/*
int data = values.DataSetsCount;
int revenue = values.RevenueCount;
int users = values.UsersCount;
int penta = values.PentaPointsCount;
int workers = values.WorkersCount;
*/