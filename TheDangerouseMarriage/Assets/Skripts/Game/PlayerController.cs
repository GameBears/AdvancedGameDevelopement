using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 0.5f, distanceAction = 1.0f;
    Room room;
    string roomString;
    string errorRoomString = "No such room!";
    GameObject actions;

	// Use this for initialization
	void Start () {
        actions = GameObject.Find("Actions");
	}
	
	// Update is called once per frame
	void Update () {
        room = GameObject.Find("Background").GetComponent<GameManagement>().room;
        roomString = getRoomString(room);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0).normalized * speed;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0).normalized * speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && roomString != errorRoomString)
        {
            foreach (Transform room in actions.transform)
            {
                if (room.name == roomString)
                {
                    foreach (Transform action in room)
                    {
                        if (Mathf.Abs(transform.position.x - action.position.x) <= distanceAction)
                        {
                            //Something happens here
                            Actions actionAction = action.GetComponent<Actions>();

                            if (actionAction != null)
                                actionAction.doAction();
                        }
                    }
                }
            }
        }
    }

    string getRoomString(Room room)
    {
        if (room == Room.KITCHEN)
        {
            return "Kitchen";
        }
        else if (room == Room.FLOOR)
        {
            return "Floor";
        }
        else if (room == Room.LIVING)
        {
            return "Living";
        }
        else if (room == Room.SLEEP)
        {
            return "Sleep";
        }
        else if (room == Room.OUTDOORS)
        {
            return "Outdoors";
        }
        else
        {
            return errorRoomString;
        }
    }
}
