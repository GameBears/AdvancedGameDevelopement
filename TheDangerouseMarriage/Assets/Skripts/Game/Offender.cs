using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offender : MonoBehaviour {
    public Sprite offenderInWeelchair;
    GameManagement gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.getDay() > 2)
        {
            GameObject chair = GameObject.Find("Chair 1");
            if (chair != null)
            {
                GameObject.Destroy(chair);
            }
        }
	}
}
