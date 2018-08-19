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
    private float eventNounce;
    Dictionary<int, bool> events = new Dictionary<int, bool>();

    // Use this for initialization
    void Start () {
        avatarButton = GetComponent<Button>();
        bubble = avatarButton.transform.Find("Canvas").gameObject.GetComponent<Canvas>();
        bubbleText = avatarButton.transform.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        avatarButton.transform.Find("Canvas").transform.position = new Vector3(avatarButton.transform.position.x, avatarButton.transform.position.y, 0);

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
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void notify(string text, int id)
    {
        Debug.Log(id);
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

    private bool agree()
    {
        Button responseOneButton = avatarButton.transform.Find("Canvas").transform.Find("AgreeButton").GetComponent<Button>();
        responseOneButton.enabled = false;
        Button responseTwoButton = avatarButton.transform.Find("Canvas").transform.Find("DisAgreeButton").GetComponent<Button>();
        responseTwoButton.enabled = false;
        return true;
    }

    private bool disagree()
    {
        Button responseOneButton = avatarButton.transform.Find("Canvas").transform.Find("AgreeButton").GetComponent<Button>();
        responseOneButton.enabled = false;
        Button responseTwoButton = avatarButton.transform.Find("Canvas").transform.Find("DisAgreeButton").GetComponent<Button>();
        responseTwoButton.enabled = false;
        return false;
    }

    public int respond(string responseOne, string responseTwo)
    {
    
        Button responseOneButton = avatarButton.transform.Find("Canvas").transform.Find("AgreeButton").GetComponent<Button>();
        responseOneButton.enabled = true;

        Text responseOneText = avatarButton.transform.Find("Canvas").transform.Find("AgreeButton").GetComponent<Text>();
        responseOneText.text = responseOne;

        Button responseTwoButton = avatarButton.transform.Find("Canvas").transform.Find("DisAgreeButton").GetComponent<Button>();
        responseTwoButton.enabled = true;

        Text responseTwoText = avatarButton.transform.Find("Canvas").transform.Find("DisAgreeButton").GetComponent<Text>();
        responseTwoText.text = responseTwo;



        return 1;
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
        expanded = false;
        bubble.enabled = false;
        unotify();
    }

    public bool response(string agree, string diagree)
    {
        return true;
    }

}
