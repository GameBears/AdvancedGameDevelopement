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
    serveFood,
    getVacuumCleaner,
    getBucket
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
            else if (action == Action.getBucket)
            { getBucket(); }
            else if (action == Action.getVacuumCleaner)
            { getVacuumCleaner(); }
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
            toDo.doMeal = true;
            done = true;

            if (gameManager.getDay() == 1)
            {
                infoText.text = "Kim: \"I am happy to see his smile while he eat this meal.\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"Today is the meal even better than yesterday.\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"Today I made him his favorite meal. He will be happy about it.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Alex: \"Did you leave the food too long? It tastes a little burnt. But I can still eat it.\"";
            }
            else if (gameManager.getDay() == 5)
            {
                if (counter == 0)
                {
                    infoText.text = "Alex: \"It is impossible to eat it. You used to much salt. Make me something else.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find("open fridge").GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find("cook food").GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else
                {
                    infoText.text = "Alex: \"It is better ... but nothing more.\"";
                    counter = 0;
                }

            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    infoText.text = "Alex: \"You were already better in cooking. This disappoints me. I will make me something else.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find("open fridge").GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find("cook food").GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else
                {
                    infoText.text = "Alex: \"I told you, I'll do something myself later.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                if (counter == 0)
                {
                    infoText.text = "Alex: \"I can not rely on you in cooking food anymore. You used to cook so well.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find("open fridge").GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find("cook food").GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else if (counter == 1)
                {
                    infoText.text = "Alex: \"No, it still does not taste good...\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find("open fridge").GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find("cook food").GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else
                {
                    infoText.text = "Alex: \"OK. That's enough now. I'm going to the city right now.\"";
                    counter = 0;
                }
            }
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
            toDo.doDishes = true;
            done = true;

            if (gameManager.getDay() == 1)
            {
                infoText.text = "Kim: \"A plate, another plate and the silverware not forgotten .... So finished.\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"A cup here and a glass there .... Now all the dishes are clear.\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"Dirty dishes hit the mood ... so we clean it away.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Alex: \"It seems that we have no more detergent. The plates are not as clean as they used to be.\"";
            }
            else if (gameManager.getDay() == 5)
            {
                if (counter == 0)
                {
                    toDo.doDishes = false;
                    infoText.text = "Alex: \"I do not eat with such dishes. There are still leftovers from the day before.\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else if (counter == 1)
                {
                    toDo.doDishes = false;
                    infoText.text = "Alex: \"What? ... you only did the cutlery? There are some leftovers on the plate aswell!\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Do I have to point out everything for you?\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    toDo.doDishes = false;
                    infoText.text = "Alex: \"I use clean dishes to eat, not filthy.\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Is it that hard? I can do it myself soon.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "Kim: \"No words ... I have no words left for that work.\"";
            }
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
            toDo.doGarbage = true;
            done = true;

            if (gameManager.getDay() == 1)
            {
                infoText.text = "Kim: \"Something has accumulated again ...\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"Today comes the gargabe collection. I'll bring the rest outside.\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"Actually, it is his turn today to bring out the garbage. But I will not bother him with it.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Alex: \"...\"";
            }
            else if (gameManager.getDay() == 5)
            {
                infoText.text = "Alex: \"Hurry up next time, that stank!\"";
            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    toDo.doGarbage = false;
                    infoText.text = "Alex: \"You have overlooked what's in the bin ... and again you go.\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Not perfect, but better.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "Alex: \"Didn't I tell you that it stinks? Don't do that when I'm here.\"";
            }
        }
        else
        {
            infoText.text = "Alex: \"This bin is empty.\"";
        }
    }

    void getVacuumCleaner()
    {
        if (!done)
        {
            GameObject.Find("vacuum").GetComponent<Actions>().active = true;

            infoText.text = "Kim: \"I have now the vacuum cleaner in my hands.\"";
            done = true;
        }
        else
        {
            infoText.text = "Kim: \"I have already the vacuum cleaner in my hands.\"";
        }
    }

    void doVacuum()
    {
        if (!done)
        {
            toDo.doVacuum = true;
            done = true;

            if (gameManager.getDay() == 1)
            {
                infoText.text = "Kim: \"A clean house is a happy house.\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"Where does all the dust come from?\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Alex: \"Maybe a dust-free home will make him a little happier.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                if (counter == 0)
                {
                    toDo.doVacuum = false;
                    infoText.text = "Alex: \"There is still some dust. Can you get rid of that fast?\"";
                    counter++;
                    setDefaultActiveDone();
                    GameObject.Find("get vacuum cleaner").GetComponent<Actions>().setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Looks better now.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 5)
            {
                infoText.text = "Alex: \"Next time you do it by hand.\"";
            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    toDo.doVacuum = false;
                    infoText.text = "Alex: \"Did you forget to vacuum?\"";
                    counter++;
                    setDefaultActiveDone();
                    GameObject.Find("get vacuum cleaner").GetComponent<Actions>().setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Next time do it immediately, please.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                if (counter == 0)
                {
                    toDo.doVacuum = false;
                    infoText.text = "Alex: \"We need a new vacuum cleaner this one  seems to be broken. It only distributes all the dirt.\"";
                    counter++;
                    setDefaultActiveDone();
                    GameObject.Find("get vacuum cleaner").GetComponent<Actions>().setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Oh ... It was just your inability.\"";
                    counter = 0;
                }
            }
        }
        else
        {
            infoText.text = "I do not need to vacuum anymore.";
        }
    }

    void getBucket()
    {
        if (!done)
        {
            GameObject.Find("window1").GetComponent<Actions>().active = true;
            GameObject.Find("window2").GetComponent<Actions>().active = true;

            infoText.text = "Kim: \"I am now ready to clean the windows.\"";
            done = true;
        }
        else
        {
            infoText.text = "Kim: \"I have already the bucket in my hands.\"";
        }
    }

    void doWindow()
    {
        if (!done)
        {
            done = true;
            int numWindowsclean = 0;
            string output = "Kim: \"I've cleaned this window.";

            if (GameObject.Find("window1").GetComponent<Actions>().done)
                numWindowsclean++;

            if (GameObject.Find("window2").GetComponent<Actions>().done)
                numWindowsclean++;

            if (numWindowsclean == 2)
            {
                toDo.doWindow = true;

                if (gameManager.getDay() == 1)
                {
                    infoText.text = "Kim: \"A clear view is the alpha and omega.\"";
                }
                else if (gameManager.getDay() == 2)
                {
                    infoText.text = "Kim: \"The cloud looks like a sheep ...\"";
                }
                else if (gameManager.getDay() == 3)
                {
                    infoText.text = "Kim: \"With a clear view, the whole situation can be perceived differently.\"";
                }
                else if (gameManager.getDay() == 4)
                {
                    infoText.text = "Alex: \"...\"";
                }
                else if (gameManager.getDay() == 5)
                {
                    if (counter == 0)
                    {
                        toDo.doWindow = false;
                        infoText.text = "Alex: \"Is it foggy outside or why do I see so badly through the windows? ... you have done this? ... Please make it better.\"";
                        counter++;
                        setDefaultActiveDone();
                        GameObject.Find("get bucket").GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find("window1").GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find("window2").GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        infoText.text = "Alex: \"Do you see? Now is it much better.\"";
                        counter = 0;
                    }
                }
                else if (gameManager.getDay() == 6)
                {
                    if (counter == 0)
                    {
                        toDo.doWindow = false;
                        infoText.text = "Alex: \"Are you doing this on purpose or why are the windows not clean yet?\"";
                        counter++;
                        setDefaultActiveDone();
                        GameObject.Find("get bucket").GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find("window1").GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find("window2").GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else if (counter == 1)
                    {
                        toDo.doWindow = false;
                        infoText.text = "Alex: \"Did you forget what cleanliness means?\"";
                        counter++;
                        setDefaultActiveDone();
                        GameObject.Find("get bucket").GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find("window1").GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find("window2").GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        infoText.text = "Alex: \"Oh, here you go.\"";
                        counter = 0;
                    }
                }
                else if (gameManager.getDay() == 7)
                {
                    infoText.text = "Alex: \"If I came to the window, I would clean it myself. But apparently that does not interest you.\"";
                }
            }
            else
            {
                output += " " + (2 - numWindowsclean) + " window left to clean.\"";
            }
            
            infoText.text = output;
        }
        else
        {
            infoText.text = "Kim: \"I have cleaned this window already.\"";
        }
    }

    void activateRadio()
    {
        if (counter > 1 && !done)
        {
            infoText.text = "Kim: \"The Radio seems to be defect.\"";
        }
        else
        {
            if (!done)
            {
                if (gameManager.getDay() == 1)
                {
                    infoText.text = "Radio: \"... the weather for today ... Sunny with some clouds ...\"";
                }
                else if (gameManager.getDay() == 2)
                {
                    infoText.text = "Radio: \"... great fire with many injured people ...\"";
                }
                else if (gameManager.getDay() == 3)
                {
                    infoText.text = "Radio: \"... the weather for today ... rainy ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 4)
                {
                    infoText.text = "Radio: \"... are popstars better in singing than diving? ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 5)
                {
                    infoText.text = "Radio: \"... the currency is stable ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 6)
                {
                    infoText.text = "Radio: \"... bad things happen everywhere ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 7)
                {
                    infoText.text = "Radio: \"... new study says dumb people have lower IQs  ...\"";
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
    {
        if (!done)
        {
        }
        else
        {

        }
    }

    void newsPaper()
    {
        if (!done)
        {
        }
        else
        {

        }
    }

    void usePhone()
    {
        if (!done)
        {
        }
        else
        {

        }
    }

    void waterPod()
    {
        if (counter >= 2)
        {
            infoText.text = "Alex: \"Stop to water this Plant. It will kill it some day. Gosh.\"";
            return;
        }

        if (!done)
        {
            if (gameManager.getDay() > 2)
            {
                counter++;
            }

            infoText.text = "Kim: \"I have watered my lovely Plant.\"";
            GameObject.Find("Plant").GetComponent<Plant>().lastDay = gameManager.getDay();
        }
        else
        {
            infoText.text = "Kim: \"I have already watered the pod.\"";
        }
    }
}
