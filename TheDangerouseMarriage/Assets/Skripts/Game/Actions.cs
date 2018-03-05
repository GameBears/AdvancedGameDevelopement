using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Action
{
    openFridge,
    DoMeal,
    DoDishes,
    DoGarbage,
    DoVacuum,
    DoWindow,
    ActivateRadio,
    LookTV,
    UsePhone,
    NewsPaper,
    WaterPod,
    serveFood
}

public class Actions : MonoBehaviour {
    ToDo toDo;
    public bool isSideQuest = false;
    public bool done = false;
    public bool active = false;
    GameManagement gameManager;
    Text infoText;
    public Action action;
    int counter = 0;

    public void setDefaultActiveDone()
    {
        if (isSideQuest)
        {
            active = false;
            done = false;
        }
        else
        {
            active = true;
            done = false;
        }
    }

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Background").GetComponent<GameManagement>();
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        toDo = GameObject.Find("ToDoText").GetComponent<ToDo>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doAction()
    {
        if (active)
        {
            if (action == Action.DoMeal)
            { doMeal(); }
            else if (action == Action.openFridge)
            { openFridge(); }
            else if (action == Action.serveFood)
            { serveFood(); }
            else if (action == Action.DoDishes)
            { doDishes(); }
            else if (action == Action.DoGarbage)
            { doGarbage(); }
            else if (action == Action.DoVacuum)
            { doVacuum(); }
            else if (action == Action.DoWindow)
            { doWindow(); }
            else if (action == Action.ActivateRadio)
            { activateRadio(); }
            else if (action == Action.LookTV)
            { lookTV(); }
            else if (action == Action.NewsPaper)
            { newsPaper(); }
            else if (action == Action.UsePhone)
            { usePhone(); }
            else if (action == Action.WaterPod)
            { waterPod(); }
        }
        else
        {
            infoText.text = "I cant use it now.";
        }
    }

    void openFridge()
    {
        if (!done)
        {
            infoText.text = "I have now some food in my hands.";
            done = true;

            Actions cookFood = GameObject.Find("cook food").GetComponent<Actions>();

            if (cookFood != null)
            {
                cookFood.active = true;
            }
        }
        else
        {
            infoText.text = "I have already got some food from the fridge.";
        }
    }

    void doMeal()
    {
        if (!done)
        {
            infoText.text = "I have cooked some food.";
            done = true;

            Actions serveFood = GameObject.Find("serve food").GetComponent<Actions>();

            if (serveFood != null)
            {
                serveFood.active = true;
            }
        }
        else
        {
            infoText.text = "I have already cooked some food.";
        }
    }

    void serveFood()
    {
        if (!done)
        {
            infoText.text = "I have served the food.";
            toDo.doMeal = true;
            done = true;
        }
        else
        {
            infoText.text = "I have already served the food.";
        }
    }

    void doDishes()
    {
        if (!done)
        {
            infoText.text = "Dishes are done.";
            toDo.doDishes = true;
            done = true;
        }
        else
        {
            infoText.text = "The dishes are clean.";
        }
    }

    void doGarbage()
    {
        if (!done)
        {
            infoText.text = "Garbage is done.";
            toDo.doGarbage = true;
            done = true;
        }
        else
        {
            infoText.text = "This bin is empty.";
        }
    }

    void doVacuum()
    {
        if (!done)
        {
            infoText.text = "Vacuum is done.";
            toDo.doVacuum = true;
            done = true;
        }
        else
        {
            infoText.text = "I dont need the vacuum machine.";
        }
    }

    void doWindow()
    {
        if (!done)
        {
            infoText.text = "Window is done.";
            toDo.doWindow = true;
            done = true;
        }
        else
        {
            infoText.text = "This window is already clean.";
        }
    }

    void activateRadio()
    {
        if (counter > 1 && !done)
        {
            infoText.text = "The Radio seems to be defect.";
        }
        else
        {
            if (!done)
            {
                if (gameManager.getDay() == 1)
                {
                    infoText.text = "Radio: '... the weather for today ... Sunny with light clouds ...'";
                }
                else if (gameManager.getDay() == 2)
                {
                    infoText.text = "Radio: '... great fire with many injured people ...'";
                }
                else if (gameManager.getDay() == 3)
                {
                    infoText.text = "Radio: '... the weather for today ... rainy ...'";
                    counter++;
                }
                else if (gameManager.getDay() == 4)
                {
                    infoText.text = "Radio: 'Welcome to the News ...'";
                    counter++;
                }
                else if (gameManager.getDay() == 5)
                {
                    infoText.text = "Radio: 'Welcome to the News ...'";
                    counter++;
                }
                else if (gameManager.getDay() == 6)
                {
                    infoText.text = "Radio: 'Welcome to the News ...'";
                    counter++;
                }
                else if (gameManager.getDay() == 7)
                {
                    infoText.text = "Radio: 'Welcome to the News ...'";
                    counter++;
                }

                done = true;
            }
            else
            {
                infoText.text = "I have already heard what's going on.";
            }
        }
    }

    void lookTV()
    { }

    void newsPaper()
    { }

    void usePhone()
    { }

    void waterPod()
    { }
}
