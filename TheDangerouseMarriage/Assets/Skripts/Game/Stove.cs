using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour {
    public Sprite stoveUsed;
    Sprite stoveUnused;
    Actions stoveAction;

    // Use this for initialization
    void Start()
    {
        stoveUnused = GetComponent<SpriteRenderer>().sprite;
        stoveAction = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stoveAction.done)
        {
            GetComponent<SpriteRenderer>().sprite = stoveUsed;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = stoveUnused;
        }
    }
}
