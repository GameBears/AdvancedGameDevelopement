using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Room
{
    KITCHEN,
    FLOOR,
    SLEEP,
    LIVING,
    BATH,
    EXIT
};

public class GameManagement : MonoBehaviour
{
    GameObject player;
    Vector3 oldPlayerPosition;
    Room room = Room.SLEEP;
    Room oldRoom = Room.SLEEP;
    int dayTimer = 1;

    public Sprite kitchenSprite;
    public Sprite floorSprite;
    public Sprite floorSpriteFinal;
    public Sprite sleepSprite;
    public Sprite livingSprite;
    public Sprite bathSprite;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        oldPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerOutOfSight();
    }

    void checkPlayerOutOfSight()
    {
        Vector3 playerPosition = player.transform.position;

        var dist = (playerPosition - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        bool leftBorderHit = playerPosition.x < leftBorder;
        bool rightBorderHit = playerPosition.x > rightBorder;

        if (leftBorderHit || rightBorderHit)
        {
            oldRoom = room;

            if (leftBorderHit)
            {
                room = getNewRoom(room, true);
            }
            else
            {
                room = getNewRoom(room, false);
            }

            if (oldRoom != room)
            {
                if (room == Room.EXIT)
                {
                    //TODO: new day
                    dayTimer = newDay(dayTimer, ref room);
                }
                else
                {
                    if (leftBorderHit)
                    {
                        player.transform.position = GameObject.Find("RightSpawn").transform.position;
                    }
                    else
                    {
                        player.transform.position = GameObject.Find("LeftSpawn").transform.position;
                    }

                    print(dayTimer);
                    this.GetComponent<SpriteRenderer>().sprite = getRoomSprite(room, dayTimer);
                }
            }
            else
            {
                player.transform.position = oldPlayerPosition;
                playerPosition = oldPlayerPosition;
            }
        }

        oldPlayerPosition = playerPosition;
    }

    Room getNewRoom(Room oldRoom, bool left)
    {
        if (oldRoom == Room.SLEEP)
        {
            if (left)
            {
                return oldRoom;
            }
            else
            {
                return Room.FLOOR;
            }
        }

        if (oldRoom == Room.FLOOR)
        {
            if (left)
            {
                return Room.SLEEP;
            }
            else
            {
                return Room.KITCHEN;
            }
        }

        if (oldRoom == Room.KITCHEN)
        {
            if (left)
            {
                return Room.FLOOR;
            }
            else
            {
                return Room.LIVING;
            }
        }

        if (oldRoom == Room.LIVING)
        {
            if (left)
            {
                return Room.KITCHEN;
            }
            else
            {
                return Room.BATH;
            }
        }

        if (oldRoom == Room.BATH)
        {
            if (left)
            {
                return Room.LIVING;
            }
            else
            {
                return Room.EXIT;
            }
        }

        return Room.EXIT;
    }

    Sprite getRoomSprite(Room room, int day)
    {
        if (room == Room.SLEEP)
        {
            return sleepSprite;
        }

        if (room == Room.LIVING)
        {
            return livingSprite;
        }

        if (room == Room.KITCHEN)
        {
            return kitchenSprite;
        }

        if (room == Room.FLOOR)
        {
            if (day > 2)
                return floorSpriteFinal;

            return floorSprite;
        }

        if (room == Room.BATH)
        {
            return bathSprite;
        }

        return sleepSprite;
    }

    int newDay(int day, ref Room room)
    {
        player.transform.position = GameObject.Find("LeftSpawn").transform.position;

        room = Room.SLEEP;
        this.GetComponent<SpriteRenderer>().sprite = getRoomSprite(room, day);

        return ++day;
    }
}

