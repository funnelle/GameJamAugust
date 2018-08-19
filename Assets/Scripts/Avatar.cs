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

	// Use this for initialization
	void Start () {
        avatarButton = GetComponent<Button>();
        bubble = avatarButton.transform.Find("Canvas").gameObject.GetComponent<Canvas>();
        bubbleText = avatarButton.transform.Find("Canvas").transform.Find("Text").GetComponent<Text>();
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

    void notify(string text)
    {
        tempSprite = bell.sprite;
        bell.sprite = redBell;
        setText(text);
        notified = true;
    }

    public string getName()
    {
        return GetComponentInChildren<Text>().text;
    }

    void unotify()
    {
        bell.sprite = tempSprite;
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
            unotify();
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
    }

}
