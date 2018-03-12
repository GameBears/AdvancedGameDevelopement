using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {
    Actions doWindow;
    bool done = false; 
    GameManagement gameManager;
    int lastDay = 0;

    public Sprite dayOneWindowDirty;
    public Sprite dayTwoWindowDirty;
    public Sprite dayFiveWindowDirty;
    public Sprite dayTenAndMoreWindowDirty;

    public Sprite dayOneWindowClean;
    public Sprite dayTwoWindowClean;
    public Sprite dayFiveWindowClean;
    public Sprite dayTenAndMoreWindowClean;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
        doWindow = GetComponent<Actions>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lastDay != gameManager.getDay() || done != doWindow.done)
        {
            lastDay = gameManager.getDay();
            done = doWindow.done;

            //Sprites für diesen Tag aktualisieren
            if (gameManager.getDay() == 1) //Tag 1
            {
                if (doWindow.done)
                {
                    GetComponent<SpriteRenderer>().sprite = dayOneWindowClean;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = dayOneWindowDirty;
                }
            }
            else if (gameManager.getDay() == 2) //Tag 2
            {
                if (doWindow.done)
                {
                    GetComponent<SpriteRenderer>().sprite = dayTwoWindowClean;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = dayTwoWindowDirty;
                }
            }
            else if (gameManager.getDay() == 3) //Tag 5
            {
                if (doWindow.done)
                {
                    GetComponent<SpriteRenderer>().sprite = dayFiveWindowClean;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = dayFiveWindowDirty;
                }
            }
            else //ab Tag 10
            {
                if (doWindow.done)
                {
                    GetComponent<SpriteRenderer>().sprite = dayTenAndMoreWindowClean;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = dayTenAndMoreWindowDirty;
                }
            }
        }
	}
}
