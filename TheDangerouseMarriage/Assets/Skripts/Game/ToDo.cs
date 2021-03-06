﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDo : MonoBehaviour {
    public bool doMeal = false;
    public bool doVacuum = false;
    public bool doGarbage = false;
    public bool doDishes = false;
    public bool doWindow = false;
    GameManagement gameManager;
    Text text;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (doMeal && doVacuum && doGarbage && doDishes && doWindow)
        {
            gameManager.newDay();
        }

        string[] toDoString = new string[6];

        toDoString[0] = "ToDos für heute:";

        if (!doMeal)
            toDoString[1] = "Essen vorbereiten ";

        if (!doVacuum)
            toDoString[2] = "Staubsaugen ";

        if (!doGarbage)
            toDoString[3] = "Müll rausbringen ";

        if (!doDishes)
            toDoString[4] = "Geschirr spülen ";

        if (!doWindow)
            toDoString[5] = "Fenster säubern ";

        string strNewToDo = toDoString[0] + "\n\n"
            + toDoString[1] + "\n"
            + toDoString[2] + "\n"
            + toDoString[3] + "\n"
            + toDoString[4] + "\n"
            + toDoString[5];

        if (strNewToDo != text.text)
        {
            text.text = strNewToDo;
        }
    }

    public void setToDoFalse()
    {
        doMeal = false;
        doDishes = false;
        doGarbage = false;
        doVacuum = false;
        doWindow = false;
    }
}
