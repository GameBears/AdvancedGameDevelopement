using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Room
{
    KITCHEN,
    FLOOR,
    SLEEP,
    LIVING,
    OUTDOORS,
    NEWDAY,
    SEQUENCE
};

public class GameManagement : MonoBehaviour
{
    GameObject player, leftSpawn, rightSpawn;
    Vector3 oldPlayerPosition;
    Room room = Room.SLEEP;
    Room oldRoom = Room.SLEEP;
    int dayCounter = 1;

    bool toDoMeal = false;
    bool toDoVacuum = false;
    bool toDoGarbage = false;
    bool toDoDishes = false;
    bool toDoWindow = false;

    public Sprite kitchenSprite;
    public Sprite floorSprite;
    public Sprite floorSpriteFinal;
    public Sprite sleepSprite;
    public Sprite livingSprite;
    public Sprite outDoorsSprite;
    public float outOfRoomAlpha;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        leftSpawn = GameObject.Find("LeftSpawn");
        rightSpawn = GameObject.Find("RightSpawn");
        oldPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerOutOfSight();

        checkToDoListComplete();
    }

    void checkToDoListComplete()
    {
        if (toDoMeal && toDoVacuum && toDoGarbage && toDoDishes && toDoWindow)
        {
            dayCounter = newDay(dayCounter, ref room);
        }
    }

    void checkPlayerOutOfSight()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 leftSpawnPosition = leftSpawn.transform.position;
        Vector3 rightSpawnPosition = rightSpawn.transform.position;
        
        bool leftBorderHit = playerPosition.x < leftSpawnPosition.x - outOfRoomAlpha;
        bool rightBorderHit = playerPosition.x > rightSpawnPosition.x + outOfRoomAlpha;

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
                if (leftBorderHit)
                {
                    player.transform.position = GameObject.Find("RightSpawn").transform.position;
                }
                else
                {
                    player.transform.position = GameObject.Find("LeftSpawn").transform.position;
                }

                this.GetComponent<SpriteRenderer>().sprite = getRoomSprite(room, dayCounter);
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
                return Room.OUTDOORS;
            }
        }

        if (oldRoom == Room.OUTDOORS)
        {
            if (left)
            {
                return Room.LIVING;
            }
            else
            {
                return Room.OUTDOORS;
            }
        }

        return oldRoom;
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

        if (room == Room.OUTDOORS)
        {
            return outDoorsSprite;
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

