using System.Collections;
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
    public bool waitForNewDay = false;
    public float waitForNewDayWaitTime = 1.0f;
    float waitForNewDayStart = 0;
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

        doNewDay();
        setRoomSprites();
        oldRoom = room;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForNewDay)
        {
            if (GameObject.Find("InfoText").GetComponent<Text>().text == "")
            {
                if (waitForNewDayStart == 0)
                {
                    waitForNewDayStart = Time.realtimeSinceStartup;
                }
                else
                {
                    if (Mathf.Abs(waitForNewDayStart - Time.realtimeSinceStartup) > waitForNewDayWaitTime)
                    {
                        waitForNewDay = false;
                        doNewDay();
                        waitForNewDayStart = 0;
                    }
                }
            }
        }
        else
        {
            player.GetComponent<PlayerController>().checkPlayerInput();
            checkPlayerOutOfSight();
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
        Transform furnitureRoom = furniture.transform.Find(name);

        if (furnitureRoom != null)
        {
            foreach (Transform furnitureInRoom in furnitureRoom)
            {
                SpriteChanger spriteChanger = furnitureInRoom.GetComponent<SpriteChanger>();
                string layerName = "Furniture";

                if (spriteChanger != null)
                {
                    spriteChanger.refresh();

                    if (!spriteChanger.isVisible())
                    {
                        layerName = "NotVisible";
                    }
                }

                furnitureInRoom.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }
        }
    }

    public void newDay()
    {
        waitForNewDay = true;
    }

    void doNewDay()
    {
        //loadSequenceImages(dayCounter);

        resetActions();

        GameObject.Find("ToDoText").GetComponent<ToDo>().setToDoFalse();

        room = Room.SLEEP;

        Vector3 newPosition = player.transform.position;

        newPosition.x = leftSpawn.transform.position.x;

        player.transform.position = newPosition;

        player.GetComponent<SpriteRenderer>().flipX = false;

        dayCounter++;
        setDayWatch();
        dayStartText();

        setRoomSprites();

        if (dayCounter > 7)
        {
            showBadEnding();
        }
    }

    void resetActions()
    {
        foreach (Transform room in furniture.transform)
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

    void setDayWatch()
    {
        GameObject.Find("DayWatch").GetComponent<Text>().text = "Tag " + getRealDay();
    }

    int getRealDay()
    {
        if (dayCounter == 2)
        {
            return 2;
        }
        else if (dayCounter == 3)
        {
            return 5;
        }
        else if (dayCounter == 4)
        {
            return 10;
        }
        else if (dayCounter == 5)
        {
            return 20;
        }
        else if (dayCounter == 6)
        {
            return 32;
        }
        else if (dayCounter == 7)
        {
            return 45;
        }

        return 1;
    }

    void dayStartText()
    {
        Text infoText = GameObject.Find("InfoText").GetComponent<Text>();

        if (dayCounter == 1)
        {
            infoText.text = "Kim: \"Bald ist die Arbeit vorbei und wir können gemeinsam Zeit verbringen. Aber vorher muss ich noch einiges erledigen.\"";
        }
        else if (dayCounter == 2)
        {
            infoText.text = "Kim: \"Es ist immerso schön nach der Arbeit Zeit miteinander zu verbringen.\"";
        }
        else if (dayCounter == 3)
        {
            infoText.text = "Kim: \"So viele Arztbesuche mit ihm. Ich werde ihm einen schönen Tag bereiten\"";
        }
        else if (dayCounter == 4)
        {
            infoText.text = "Kim: \"Irgendwann wird es ihm schon besser gehen.\"";
        }
        else if (dayCounter == 5)
        {
            infoText.text = "Kim: \"Motivation für Tag 20.\"";
        }
        else if (dayCounter == 6)
        {
            infoText.text = "Kim: \"Motivation für Tag 32.\"";
        }
        else if (dayCounter == 7)
        {
            infoText.text = "Kim: \"Motivation für Tag 45.\"";
        }
    }

    public void showGoodEnding()
    {
    }

    void showBadEnding()
    {
    }
}

