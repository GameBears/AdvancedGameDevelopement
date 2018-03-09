using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {
    float disapearingTime = 3.0f;
    public int wordsPerMinute = 200;
    Text text;
    float lastUpdate;
    bool changed = false;
    string oldText = "";
    PlayerController playerControl;
    Color colorKim, colorAlex;
    public Color colorMale, colorFemale;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        //oldText = text.text;

        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();

        if (playerControl.isMale)
        {
            colorKim = colorMale;
            colorAlex = colorFemale;
        }
        else
        {
            colorKim = colorFemale;
            colorAlex = colorMale;
        }
    }

    void setColor()
    {
        if (text.text.Contains("Kim:"))
        {
            text.color = colorKim;
        }
        else if (text.text.Contains("Alex:"))
        {
            text.color = colorAlex;
        }
        else
        {
            text.color = Color.white;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (oldText != text.text)
        {
            setColor();
            lastUpdate = Time.realtimeSinceStartup;
            oldText = text.text;

            int num_Words = oldText.Split().Length;

            disapearingTime = num_Words / (wordsPerMinute / 60);
        }

        if (Mathf.Abs(lastUpdate - Time.realtimeSinceStartup) > disapearingTime)
        {
            text.text = "";
            oldText = text.text;
        }
	}
}
