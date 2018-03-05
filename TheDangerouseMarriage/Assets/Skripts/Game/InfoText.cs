using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {
    float disapearingTime = 3.0f;
    public int wordsPerMinute = 150;
    Text text;
    float lastUpdate;
    bool changed = false;
    string oldText = "";

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        oldText = text.text;
    }
	
	// Update is called once per frame
	void Update () {
        if (oldText != text.text)
        {
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
