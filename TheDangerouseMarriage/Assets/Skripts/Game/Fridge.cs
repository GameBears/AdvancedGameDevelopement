using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour {
    public Sprite fridgeUsed;
    Sprite fridgeUnused;
    Actions fridgeAction;

    // Use this for initialization
    void Start()
    {
        fridgeUnused = GetComponent<SpriteRenderer>().sprite;
        fridgeAction = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fridgeAction.done)
        {
            GetComponent<SpriteRenderer>().sprite = fridgeUsed;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = fridgeUnused;
        }
    }
}
