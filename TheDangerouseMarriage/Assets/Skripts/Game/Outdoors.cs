using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outdoors : MonoBehaviour {
    public Sprite outdoorsDayOne;
    public Sprite outdoorsDayTwo;
    public Sprite outdoorsDayFive;
    public Sprite outdoorsMoreThanDayTen;
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
            lastDay = gameManager.getDay();

            if (lastDay == 1)
            {
                gameManager.outDoorsSprite = outdoorsDayOne;
            }
            else if (lastDay == 2)
            {
                gameManager.outDoorsSprite = outdoorsDayTwo;
            }
            else if (lastDay == 3)
            {
                gameManager.outDoorsSprite = outdoorsDayFive;
            }
            else
            {
                gameManager.outDoorsSprite = outdoorsMoreThanDayTen;
            }
        }
	}
}
