using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour {
    public Sprite servedTable;
    Sprite table;
    ToDo toDoList;

	// Use this for initialization
	void Start () {
        table = GetComponent<SpriteRenderer>().sprite;
        toDoList = GameObject.Find("ToDoText").GetComponent<ToDo>();
    }
	
	// Update is called once per frame
	void Update () {
        if (toDoList.doMeal)
        {
            GetComponent<SpriteRenderer>().sprite = servedTable;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = table;
        }
    }
}
