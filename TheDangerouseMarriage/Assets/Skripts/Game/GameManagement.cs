﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Room
{
    KITCHEN,
    FLOOR,
    SLEEP,
    LIVING,
    OUTDOORS,
    NEWDAY
};

public class GameManagement : MonoBehaviour
{
    GameObject player, leftSpawn, rightSpawn, furniture;
    //Queue<Sprite> sequence = new Queue<Sprite>();

    Vector3 oldPlayerPosition;
    public Room room;
    Room oldRoom;
    int dayCounter = 0;

    public Sprite kitchenSprite;
    public Sprite floorSprite;
    public Sprite floorSpriteFinal;
    public Sprite sleepSprite;
    public Sprite livingSprite;
    public Sprite outDoorsSprite;
    public float outOfRoomAlpha;

    public int getDay()
    {
        return dayCounter;
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        leftSpawn = GameObject.Find("LeftSpawn");
        rightSpawn = GameObject.Find("RightSpawn");
        furniture = GameObject.Find("Furniture");
        oldPlayerPosition = player.transform.position;

        newDay();
        setRoomSprites();
        oldRoom = room;
    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerOutOfSight();
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
                Vector3 newPosition = player.transform.position;

                if (leftBorderHit)
                {
                    newPosition.x = rightSpawn.transform.position.x;
                }
                else
                {
                    newPosition.x = leftSpawn.transform.position.x;
                }

                player.transform.position = newPosition;

                setRoomSprites();
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

    void setRoomSprites()
    {
        Sprite roomSprite;

        foreach (Transform furnitureRooms in furniture.transform)
        {
            foreach (Transform furnitureInRoom in furnitureRooms)
            {
                furnitureInRoom.GetComponent<SpriteRenderer>().sortingLayerName = "NotVisible";
            }
        }

        if (room == Room.SLEEP)
        {
            showFurnitureInRoom("Sleep");

            roomSprite = sleepSprite;
        }
        else if (room == Room.LIVING)
        {
            showFurnitureInRoom("Living");

            roomSprite = livingSprite;
        }
        else if (room == Room.KITCHEN)
        {
            showFurnitureInRoom("Kitchen");

            roomSprite = kitchenSprite;
        }
        else if (room == Room.FLOOR)
        {
            showFurnitureInRoom("Floor");

            roomSprite = floorSprite;
        }
        else if (room == Room.OUTDOORS)
        {
            showFurnitureInRoom("Outdoors");

            roomSprite = outDoorsSprite;
        }
        else
        {
            roomSprite = sleepSprite;
        }

        this.GetComponent<SpriteRenderer>().sprite = roomSprite;
    }

    void showFurnitureInRoom(string name)
    {
        Transform furnitureRoom= furniture.transform.Find(name);

        if (furnitureRoom != null)
        {
            foreach (Transform furnitureInRoom in furnitureRoom)
            {
                furnitureInRoom.GetComponent<SpriteRenderer>().sortingLayerName = "Furniture";
            }
        }
    }

    public void newDay()
    {
        //loadSequenceImages(dayCounter);

        resetActions();

        GameObject.Find("ToDoText").GetComponent<ToDo>().setToDoFalse();

        room = Room.SLEEP;

        changeSpritesForNewDay();

        setRoomSprites();

        Vector3 newPosition = player.transform.position;

        newPosition.x = leftSpawn.transform.position.x;

        player.transform.position = newPosition;

        player.GetComponent<SpriteRenderer>().flipX = false;

        dayCounter++;
    }

    void changeSpritesForNewDay()
    {
        if (dayCounter == 2)
        { }
        else if (dayCounter == 3)
        { }
        else if (dayCounter == 4)
        { }
        else if (dayCounter == 5)
        { }
        else if (dayCounter == 6)
        { }
        else if (dayCounter == 7)
        { }
    }

    void resetActions()
    {
        foreach (Transform room in GameObject.Find("Actions").transform)
        {
            foreach (Transform action in room)
            {
                Actions actionAction = action.GetComponent<Actions>();

                if (actionAction != null)
                {
                    actionAction.setDefaultActiveDone();
                }
            }
        }
    }
}
