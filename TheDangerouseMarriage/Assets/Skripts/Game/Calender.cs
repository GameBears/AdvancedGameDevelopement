using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calender : MonoBehaviour {
    public Sprite day1, day2, day5, day10, day20, day32, day45;
    GameManagement gameManager;
    int lastDay = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lastDay != gameManager.getDay())
        {
            Sprite actual = day1;

            if (gameManager.getDay() == 2)
            {
                actual = day2;
            }
            else if (gameManager.getDay() == 3)
            {
                actual = day5;
            }
            else if (gameManager.getDay() == 4)
            {
                actual = day10;
            }
            else if (gameManager.getDay() == 5)
            {
                actual = day20;
            }
            else if (gameManager.getDay() == 6)
            {
                actual = day32;
            }
            else if (gameManager.getDay() == 7)
            {
                actual = day45;
            }

            GetComponent<SpriteRenderer>().sprite = actual;

            lastDay = gameManager.getDay();
        }
    }
}
