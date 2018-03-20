using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {
    bool visible = false;
    public int dayToShow = 1;
    public int dayToHide;
    public bool destroyable = false;
    public int dayToDestroy;
    public Sprite destroyedObject;
    GameManagement gameManager;
    SpriteRenderer spriteRenderer;
    int lastSpriteChange = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void refresh()
    {
        if (gameManager == null)
            return;

        if (lastSpriteChange != gameManager.getDay())
        {
            lastSpriteChange = gameManager.getDay();

            if (destroyable)
            {
                if (gameManager.getDay() == dayToDestroy)
                {
                    spriteRenderer.sprite = destroyedObject;
                }
            }

            if (gameManager.getDay() >= dayToHide && dayToHide != 0)
            {
                visible = false;
            }
            else if (gameManager.getDay() >= dayToShow && dayToShow != 0)
            {
                visible = true;
            }
        }
    }

    public bool isVisible()
    {
        return visible;
    }
}
