using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour {
    public Sprite trashSauber;
    Sprite trashSchmutzig;
    Actions trashAction;

	// Use this for initialization
	void Start () {
        trashSchmutzig = GetComponent<SpriteRenderer>().sprite;
        trashAction = GetComponent<Actions>();
	}
	
	// Update is called once per frame
	void Update () {
        if (trashAction.done)
        {
            GetComponent<SpriteRenderer>().sprite = trashSauber;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = trashSchmutzig;
        }
	}
}
