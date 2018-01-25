using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    GameObject player;
    Vector3 oldPlayerPosition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        oldPlayerPosition = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        checkPlayerPosition();
	}

    void checkPlayerPosition()
    {
        Vector3 playerPosition = player.transform.position;

        var dist = (playerPosition - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        if (playerPosition.x < leftBorder || playerPosition.x > rightBorder)
        {
            player.transform.position = oldPlayerPosition;
            playerPosition = oldPlayerPosition;
        }

        oldPlayerPosition = playerPosition;
    }
}
