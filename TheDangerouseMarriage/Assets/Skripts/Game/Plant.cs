using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    int counter = 0;
    public int lastDay = 1;
    public Sprite deadPlant;
    GameManagement gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.getDay() > 0 && deadPlant != GetComponent<SpriteRenderer>().sprite)
        {
            if (Mathf.Abs(gameManager.getDay() - lastDay) >= 2)
            {
                GetComponent<SpriteRenderer>().sprite = deadPlant;
            }
        }
	}
}
