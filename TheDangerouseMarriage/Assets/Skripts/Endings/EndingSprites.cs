using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSprites : MonoBehaviour {
    public Sprite[] sprites;
    int actualSprite = -1;
    bool quit = false;
    public float disapearingTime = 3.0f;
    float lastUpdate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!quit)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                actualSprite++;

                if (actualSprite == sprites.Length)
                {
                    lastUpdate = Time.realtimeSinceStartup;
                    quit = true;
                }

                GetComponent<SpriteRenderer>().sprite = sprites[actualSprite];
            }
        }
        else
        {
            if (Mathf.Abs(lastUpdate - Time.realtimeSinceStartup) > disapearingTime)
            {
                Application.Quit();
            }
        }
	}
}
