using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 0.5f, distanceAction = 1.0f;
    Room room;
    string roomString;
    string errorRoomString = "No such room!";
    GameObject actions, furniture;

	// Use this for initialization
	void Start () {
        actions = GameObject.Find("Actions");
        furniture = GameObject.Find("Furniture");
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void checkPlayerInput()
    {
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

        if (roomString != errorRoomString)
        {
            float minDist = float.MaxValue;
            GameObject nearestObject = null;

            foreach (Transform room in furniture.transform)
            {
                if (room.name == roomString)
                {
                    foreach (Transform obj in room)
                    {
                        obj.GetComponent<SpriteRenderer>().color = Color.white;
                        float dist = Mathf.Abs(transform.position.x - obj.transform.position.x);

                        if (dist <= distanceAction)
                        {
                            if (dist < minDist && obj.GetComponent<Actions>() != null)
                            {
                                minDist = dist;
                                nearestObject = obj.gameObject;
                            }
                        }
                    }
                }
            }

            if (nearestObject != null && minDist != float.MaxValue)
            {
                Actions nearastAction = nearestObject.GetComponent<Actions>();

                if (!nearastAction.done && nearastAction.active)
                    nearestObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 0.7f, 1.0f);

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    nearastAction.doAction();
                }
            }
        }
        else
        {
            print("Room not found!");
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
