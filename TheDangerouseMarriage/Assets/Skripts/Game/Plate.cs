using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {
    public Sprite cleanPlate;
    Sprite plate;
    ToDo toDoList;

    // Use this for initialization
    void Start()
    {
        plate = GetComponent<SpriteRenderer>().sprite;
        toDoList = GameObject.Find("ToDoText").GetComponent<ToDo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toDoList.doDishes)
        {
            GetComponent<SpriteRenderer>().sprite = cleanPlate;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = plate;
        }
    }
}
