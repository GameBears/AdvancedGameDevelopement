using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShoeMode
{
    NOTVISIBLETILL,
    VISIBLEFROM
}

public class Shoes : MonoBehaviour {
    public ShoeMode mode;
    public int day;
    GameManagement gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == ShoeMode.NOTVISIBLETILL)
        {
            if (gameManager.getDay() <= day)
            {
                GetComponent<SpriteRenderer>().sortingLayerName = "NotVisible";
            }
        }
        else
        {
            if (gameManager.getDay() >= day)
            {
                GetComponent<SpriteRenderer>().sortingLayerName = "NotVisible";
            }
        }
	}
}
