using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutlery : MonoBehaviour {
    public Sprite cleanCutlery;
    Sprite cutlery;
    ToDo toDoList;

	// Use this for initialization
	void Start () {
        cutlery = GetComponent<SpriteRenderer>().sprite;
        toDoList = GameObject.Find("ToDoText").GetComponent<ToDo>();
	}
	
	// Update is called once per frame
	void Update () {
        if (toDoList.doDishes)
        {
            GetComponent<SpriteRenderer>().sprite = cleanCutlery;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = cutlery;
        }
	}
}
