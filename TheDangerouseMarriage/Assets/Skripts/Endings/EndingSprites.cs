using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSprites : MonoBehaviour {
    public Sprite[] spritesMale;
    public Sprite[] spritesFemale;
    int actualSprite = 0;
    bool quit = false;
    public float disapearingTime = 3.0f;
    float lastUpdate;
    int length = 0;
    public bool doEnding = false;

    // Use this for initialization
    void Start () {
        if (!doEnding)
        {
            GameObject player = GameObject.Find("Player");

            if (player != null)
            {
                //isMale = player.GetComponent<PlayerController>().isMale;
            }
        }
        else
        {
            if (GenderSaver.IsMale)
            {
                GetComponent<SpriteRenderer>().sprite = spritesMale[0];
                length = spritesMale.Length;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = spritesFemale[0];
                length = spritesFemale.Length;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (doEnding)
        {
            if (!quit)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    actualSprite++;

                    if (actualSprite == length)
                    {
                        lastUpdate = Time.realtimeSinceStartup;
                        quit = true;
                    }

                    if (actualSprite < length)
                    {
                        if (GenderSaver.IsMale)
                        {
                            GetComponent<SpriteRenderer>().sprite = spritesMale[actualSprite];
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().sprite = spritesFemale[actualSprite];
                        }
                    }
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
}
