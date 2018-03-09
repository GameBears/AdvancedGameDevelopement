using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioCable : MonoBehaviour {
    public Sprite destroyedCable;
    Actions action;
    GameManagement gameManager;
    int lastDay = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
        action = GameObject.Find("Radio").GetComponent<Actions>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lastDay != gameManager.getDay())
        {
            if (action.counter >= 2)
            {
                GetComponent<SpriteRenderer>().sprite = destroyedCable;
            }

            lastDay = gameManager.getDay();
        }
	}
}
