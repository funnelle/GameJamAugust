using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Avatar : MonoBehaviour {
    
    bool expanded;
    bool notified;
    public Button avatarButton; 
    public Canvas bubble;
    public Text bubbleText;
    public Image bell;
    public Sprite redBell;
    private Sprite tempSprite;
    private WorkAreaController values;

    private float eventNounce;
    Dictionary<int, bool> events = new Dictionary<int, bool>();

    // Use this for initialization
    void Start () {



        values = GameObject.Find("Action Hub").GetComponent<WorkAreaController>();

        avatarButton = GetComponent<Button>();
        bubble = avatarButton.transform.Find("Canvas").gameObject.GetComponent<Canvas>();
        bubbleText = avatarButton.transform.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        avatarButton.transform.Find("Canvas").transform.position = new Vector3(avatarButton.transform.position.x - 100, avatarButton.transform.position.y -30, 0);

        avatarButton.onClick.AddListener(OnClick);
        bell = avatarButton.transform.Find("Bell").GetComponent<Image>();

        Sprite[] sprites;
        sprites = Resources.LoadAll<Sprite>("RedBell");
        redBell = sprites[0];

        Sprite[] sprites2;
        sprites2 = Resources.LoadAll<Sprite>("Glyphicons");
        bell.sprite = sprites2[0];
    
        bubble.enabled = false;
        expanded = false;

        GameObject responseOneButton = bubble.transform.Find("AgreeButton").gameObject;
        responseOneButton.SetActive(false);
        GameObject responseTwoButton = bubble.transform.Find("DisagreeButton").gameObject;
        responseTwoButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void notify(string text, int id)
    {
   
        bool item;
        if (!events.TryGetValue(id, out item))
        {
            events[id] = true;
            tempSprite = bell.sprite;
            bell.sprite = redBell;
            setText(text);
            notified = true;
        }
    }

    private void resolve(int[] changedValues, int id)
    {
 
        events[id] = true;
        Debug.Log(changedValues[3]);
        values.DataSetsCount += changedValues[0];
        values.RevenueCount += changedValues[1];
        values.UsersCount += changedValues[2];
        values.PentaPointsCount += changedValues[3];
        values.WorkersCount += changedValues[4];
           
        collapse();
        values.SetCountText();
        
    }
    

    public void respond(string responseOne, string responseTwo, int[] valuesWhenAggree, int[] valuesWhenDisAggree, int id)
    {
        bool item;
        if (!events.TryGetValue(id, out item))
        {
            events[id] = true;
            
            GameObject responseOneButton = bubble.transform.Find("AgreeButton").gameObject;
            responseOneButton.SetActive(true);
            GameObject responseTwoButton = bubble.transform.Find("DisagreeButton").gameObject;
            responseTwoButton.SetActive(true);

            Button responseOneButtonB = responseOneButton.GetComponent<Button>();
            Button responseTwoButtonB = responseTwoButton.GetComponent<Button>();

            Text responseOneText = responseOneButtonB.transform.Find("Text").GetComponent<Text>();
            responseOneText.text = responseOne;

            Text responseTwoText = responseTwoButtonB.transform.Find("Text").GetComponent<Text>();
            responseTwoText.text = responseTwo;

            responseOneButtonB.onClick.AddListener(delegate { resolve(valuesWhenAggree, id); });
            responseTwoButtonB.onClick.AddListener(delegate { resolve(valuesWhenDisAggree, id); });
        }
    }
    public void setName(string name)
    {
        GetComponentInChildren<Text>().text = name;
    }
    public string getName()
    {
        return GetComponentInChildren<Text>().text;
    }

    void unotify()
    {
        Sprite[] sprites2;
        sprites2 = Resources.LoadAll<Sprite>("Glyphicons");
        bell.sprite = sprites2[0];
        notified = false;

    }

    void setText(string text)
    {

        bubbleText.text = text;
    }

    void OnClick()
    {
 
        if (!expanded && notified)
        {
            expand();
        }
        else
        {
            collapse();
        }
        
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
        GameObject responseOneButton = bubble.transform.Find("AgreeButton").gameObject;
        responseOneButton.SetActive(false);
        GameObject responseTwoButton = bubble.transform.Find("DisagreeButton").gameObject;
        responseTwoButton.SetActive(false);

        expanded = false;
        bubble.enabled = false;
        unotify();
    }

    public bool response(string agree, string diagree)
    {
        return true;
    }

}
