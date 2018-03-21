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
    getBucket,
    emptyBin
}

public class Actions : MonoBehaviour {
    static bool gotNumber = false;
    ToDo toDo;
    public bool isSideQuest = false;
    public bool done = false;
    public bool active = false;
    GameManagement gameManager;
    Text infoText;
    public Action action;
    public int counter = 0;
    string stove = "Stove", fridge = "Fridge", table = "Table", trashBinBig = "TrashBinBig", trash = "Trash",
        mud = "mud", window1 = "Window1", window2 = "Window2", bucket = "bucket", vacuumCleaner = "vacuum cleaner";

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
            else if (action == Action.emptyBin)
            { emptyBin(); }
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
            if (!active && !done)
            {
                if (action == Action.DoMeal)
                { infoText.text = "Kim: \"Ich sollte zunächst Essen aus dem Kühlschrank holen.\""; }
                else if (action == Action.serveFood)
                { infoText.text = "Kim: \"Ich sollte zunächst Essen vorbereiten, bevor ich den Tisch decke.\""; }
                else if (action == Action.DoGarbage)
                { infoText.text = "Kim: \"Ich sollte zunächst den Müll aus der Küche holen.\""; }
                else if (action == Action.DoVacuum)
                { infoText.text = "Kim: \"Ich benötige hierfür den Staubsauger.\""; }
                else if (action == Action.DoWindow)
                { infoText.text = "Kim: \"Ich benötige einen Eimer mit Wasser hierfür.\""; }
                else
                { infoText.text = "Kim: \"Ich kann das noch nicht machen. Ich muss noch etwas vorbereiten.\""; }
            }
        }
    }

    void openFridge()
    {
        if (!done)
        {
            infoText.text = "Kim: \"Jetzt kann ich was kochen.\"";
            done = true;

            Actions cookFood = GameObject.Find(stove).GetComponent<Actions>();

            if (cookFood != null)
            {
                cookFood.active = true;
            }
        }
        else
        {
            infoText.text = "Kim: \"Ich habe bereits etwas aus dem Kühlschrank genommen.\"";
        }
    }

    void doMeal()
    {
        if (!done)
        {
            infoText.text = "Kim: \"Ich habe etwas gekocht.\"";
            done = true;

            Actions serveFood = GameObject.Find(table).GetComponent<Actions>();

            if (serveFood != null)
            {
                serveFood.active = true;
            }
        }
        else
        {
            infoText.text = "Kim: \"Ich habe bereits gekocht.\"";
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
                infoText.text = "Kim: \"Gemeinsam zu essen ist doch das Schönste.\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"Heute habe ich das Essen noch besser hinbekommen, als gestern.\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"Heute habe ich unser Lieblingsessen gemacht.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Alex: \"Hast du das Essen zu lange stehen lassen? Es schmeckt angebrannt ... ist aber noch genießbar.\"";
            }
            else if (gameManager.getDay() == 5)
            {
                if (counter == 0)
                {
                    infoText.text = "Alex: \"Das kann man ja gar nicht essen. Das ist komplett übersalzen. Mach mir was anderes.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find(fridge).GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find(stove).GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else
                {
                    infoText.text = "Alex: \"Ist jetzt ok ... könnte aber besser sein.\"";
                    counter = 0;
                }

            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    infoText.text = "Alex: \"Du hast schon besser gekocht. Das enttäuscht mich. Mach das nochmal.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find(fridge).GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find(stove).GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else
                {
                    infoText.text = "Alex: \"Widerlich. Da muss ich mir gleich was selbst machen.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                if (counter == 0)
                {
                    infoText.text = "Alex: \"Man kann sich beim Kochen nicht mehr auf dich verlassen. Du warst früher so gut darin. Versuchs gleich nochmal.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find(fridge).GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find(stove).GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else if (counter == 1)
                {
                    infoText.text = "Alex: \"Nein, schmeckt immer noch nicht ... nochmal.\"";
                    toDo.doMeal = false;
                    setDefaultActiveDone();
                    GameObject.Find(fridge).GetComponent<Actions>().setDefaultActiveDone();
                    GameObject.Find(stove).GetComponent<Actions>().setDefaultActiveDone();
                    counter++;
                }
                else
                {
                    infoText.text = "Alex: \"Ok das reicht. Ich besorg mir was in der Stadt.\"";
                    counter = 0;
                }
            }
        }
        else
        {
            infoText.text = "Kim: \"Das Essen ist bereits fertig.\"";
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
                infoText.text = "Kim: \"Sauberes Geschir macht das Essen gleich leckerer.\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"Eine Tasse hier und ein Glas da ... nun ist das ganze Geschirr wieder klar.\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"Dreckiges Geschirr schlägt auf die Stimmung ... also weg damit.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Alex: \"Es scheint so, dass wir kein Spülmittel mehr haben. Die Teller sind nicht mehr so sauber wie früher.\"";
            }
            else if (gameManager.getDay() == 5)
            {
                if (counter == 0)
                {
                    toDo.doDishes = false;
                    infoText.text = "Alex: \"Mit solch einem Besteck ess ich doch nicht. Da sind ja noch Reste vom Vortag dran. Mach das nochmal.\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else if (counter == 1)
                {
                    toDo.doDishes = false;
                    infoText.text = "Alex: \"Wie? … Du hast nur das Besteck gemacht? An dem Teller ist ja auch noch was dran! Mach das gleich nochmal.\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Muss man dich auf alles hinweisen?\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    toDo.doDishes = false;
                    infoText.text = "Alex: \"Man benutzt sauberes Geschirr zum Essen, nicht Dreckiges. Mach das nochmal.\"";
                    counter++;
                    setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Ist das so schwer? Bald kann ich das selber machen.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "Kim: \"Keine Worte… Ich hab dafür keine Worte mehr.\"";
            }
        }
        else
        {
            infoText.text = "Kim: \"Das Geschirr ist bereits sauber.\"";
        }
    }

    void emptyBin()
    {
        if (!done)
        {
            infoText.text = "Kim: \"Jetzt muss ich den Müll noch rausbringen.\"";
            done = true;

            Actions doGarbage = GameObject.Find(trashBinBig).GetComponent<Actions>();

            if (doGarbage != null)
            {
                doGarbage.active = true;
            }
        }
        else
        {
            infoText.text = "Kim: \"Der Mülleimer ist leer.\"";
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
                infoText.text = "Kim: \"Wie schnell sich der Müll doch ansammelt.\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"Heute kommt die Müllabfuhr. Gut dass ich das jetzt noch gemacht habe.\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"Eigentlich war ich heute nicht an der Reihe, den Müll rauszubringen. Aber ich sollte nicht nur an mich denken.\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Alex: \"...\"";
            }
            else if (gameManager.getDay() == 5)
            {
                infoText.text = "Alex: \"Beeil dich beim nächsten Mal, das hat ja gestunken!\"";
            }
            else if (gameManager.getDay() == 6)
            {
                if (counter == 0)
                {
                    toDo.doGarbage = false;
                    infoText.text = "Alex: \"Du hast was im Mülleimer übersehen ... nochmal.\"";
                    counter++;
                    GameObject.Find(trash).GetComponent<Actions>().setDefaultActiveDone();
                    setDefaultActiveDone();
                }
                else
                {
                    infoText.text = "Alex: \"Nicht perfekt, aber besser.\"";
                    counter = 0;
                }
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "Alex: \"Hab ich dir nicht schon mal gesagt, dass das stinkt? Lass das, wenn ich hier bin.\"";
            }
        }
        else
        {
            infoText.text = "Kim: \"Den Müll habe ich schon weggebracht.\"";
        }
    }

    void getVacuumCleaner()
    {
        if (!done)
        {
            foreach (GameObject mud in GameObject.FindGameObjectsWithTag(mud))
            {
                mud.GetComponent<Actions>().active = true;
            }

            infoText.text = "Kim: \"Jetzt kann ich Staub saugen.\"";
            done = true;
        }
        else
        {
            infoText.text = "Kim: \"Ich habe bereits den Staubsauger genommen.\"";
        }
    }

    void doVacuum()
    {
        if (!done)
        {
            done = true;
            bool allMudsRemoved = true;

            foreach (GameObject mud in GameObject.FindGameObjectsWithTag(mud))
            {
                if (!mud.GetComponent<Actions>().done)
                {
                    allMudsRemoved = false;
                }
            }

            if (allMudsRemoved)
            {

                toDo.doVacuum = true;

                if (gameManager.getDay() == 1)
                {
                    infoText.text = "Kim: \"Ein sauberes Haus ist ein glückliches Haus.\"";
                }
                else if (gameManager.getDay() == 2)
                {
                    infoText.text = "Kim: \"Woher kommt denn nur der ganze Staub wieder her?\"";
                }
                else if (gameManager.getDay() == 3)
                {
                    infoText.text = "Kim: \"Ein staubfreies Zuhause macht gleich ein wenig glücklicher.\"";
                }
                else if (gameManager.getDay() == 4)
                {
                    if (counter == 0)
                    {
                        toDo.doVacuum = false;
                        infoText.text = "Alex: \"Es liegt immer noch Staub rum. Kannst du den schnell wegmachen?\"";
                        counter++;
                        foreach (GameObject mud in GameObject.FindGameObjectsWithTag(mud))
                        {
                            mud.GetComponent<Actions>().setDefaultActiveDone();
                        }
                        GameObject.Find(vacuumCleaner).GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        infoText.text = "Alex: \"Sieht gleich besser aus.\"";
                        counter = 0;
                    }
                }
                else if (gameManager.getDay() == 5)
                {
                    infoText.text = "Alex: \"Du solltest die kleinen stellen noch per Hand nachfegen.\"";
                }
                else if (gameManager.getDay() == 6)
                {
                    if (counter == 0)
                    {
                        toDo.doVacuum = false;
                        infoText.text = "Alex: \"Hast du vergessen zu saugen? Hol den Staubsauger und mach das nochmal.\"";
                        counter++;
                        foreach (GameObject mud in GameObject.FindGameObjectsWithTag(mud))
                        {
                            mud.GetComponent<Actions>().setDefaultActiveDone();
                        }
                        GameObject.Find(vacuumCleaner).GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        infoText.text = "Alex: \"Beim nächsten Mal strengst du dich an.\"";
                        counter = 0;
                    }
                }
                else if (gameManager.getDay() == 7)
                {
                    if (counter == 0)
                    {
                        toDo.doVacuum = false;
                        infoText.text = "Alex: \"Wir brauchen einen neuen Staubsauger, der scheint kaputt zu sein. Der verteilt den ganzen Schmutz nur noch. Mach das nochmal.\"";
                        counter++;
                        foreach (GameObject mud in GameObject.FindGameObjectsWithTag(mud))
                        {
                            mud.GetComponent<Actions>().setDefaultActiveDone();
                        }
                        GameObject.Find(vacuumCleaner).GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        infoText.text = "Alex: \"Oh...Es lag doch nur an deiner Unfähigkeit.\"";
                        counter = 0;
                    }
                }
            }
            else
            {
                infoText.text = "Kim: \"Ein Staubhaufen weniger.\"";
            }
        }
        else
        {
            infoText.text = "Kim: \"Ich brauch hier nicht mehr zu saugen.\"";
        }
    }

    void getBucket()
    {
        if (!done)
        {
            GameObject.Find(window1).GetComponent<Actions>().active = true;
            GameObject.Find(window2).GetComponent<Actions>().active = true;

            infoText.text = "Kim: \"Nun kann ich die Fenster putzen.\"";
            done = true;
        }
        else
        {
            infoText.text = "Kim: \"Den Eimer habe ich schon genommen.\"";
        }
    }

    void doWindow()
    {
        if (!done)
        {
            done = true;
            int numWindowsclean = 0;
            string output = "Kim: \"Dieses Fenster sieht sauber aus.";

            if (GameObject.Find(window1).GetComponent<Actions>().done)
                numWindowsclean++;

            if (GameObject.Find(window2).GetComponent<Actions>().done)
                numWindowsclean++;

            if (numWindowsclean == 2)
            {
                toDo.doWindow = true;

                if (gameManager.getDay() == 1)
                {
                    output = "Kim: \"Eine klare Sicht ist das A und O.\"";
                }
                else if (gameManager.getDay() == 2)
                {
                    output = "Kim: \"Die Wolke sieht ja aus wie ein Schäfchen...\"";
                }
                else if (gameManager.getDay() == 3)
                {
                    output = "Kim: \"Durch eine klare Sicht kann die ganze Lage gleich anders wahrgenommen werden.\"";
                }
                else if (gameManager.getDay() == 4)
                {
                    output = "Alex: \"...\"";
                }
                else if (gameManager.getDay() == 5)
                {
                    if (counter == 0)
                    {
                        toDo.doWindow = false;
                        output = "Alex: \"Ist es neblig draußen oder warum sieht man so schlecht durch Fenster? … Ach das warst du? ... Mach das gleich nochmal.\"";
                        counter++;
                        setDefaultActiveDone();
                        GameObject.Find(bucket).GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find(window1).GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find(window2).GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        output = "Alex: \"Siehst du? Da sieht man doch gleich mehr.\"";
                        counter = 0;
                    }
                }
                else if (gameManager.getDay() == 6)
                {
                    if (counter == 0)
                    {
                        toDo.doWindow = false;
                        output = "Alex: \"Machst du das mit Absicht oder warum sind die Fenster noch nicht sauber? ... nochmal.\"";
                        counter++;
                        setDefaultActiveDone();
                        GameObject.Find(bucket).GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find(window1).GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find(window2).GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else if (counter == 1)
                    {
                        toDo.doWindow = false;
                        output = "Alex: \"Hast du vergessen, was Sauberkeit bedeutet? Mach das besser.\"";
                        counter++;
                        setDefaultActiveDone();
                        GameObject.Find(bucket).GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find(window1).GetComponent<Actions>().setDefaultActiveDone();
                        GameObject.Find(window2).GetComponent<Actions>().setDefaultActiveDone();
                    }
                    else
                    {
                        output = "Alex: \"Na geht doch.\"";
                        counter = 0;
                    }
                }
                else if (gameManager.getDay() == 7)
                {
                    output = "Alex: \"Wenn ich an das Fenster kommen würde, dann würde ich das selbst säubern. Aber scheinbar interessiert dich das nicht.\"";
                }
            }
            else
            {
                output += " " + (2 - numWindowsclean) + " Fenster noch übrig.\"";
            }
            
            infoText.text = output;
        }
        else
        {
            infoText.text = "Kim: \"Dieses Fenster ist bereits sauber.\"";
        }
    }

    void activateRadio()
    {
        if (counter > 1 && !done)
        {
            infoText.text = "Kim: \"Das Radio funktioniert nicht mehr.\"";
        }
        else
        {
            if (!done)
            {
                if (gameManager.getDay() == 1)
                {
                    infoText.text = "Radio: \"... das Wetter für heute ... Sonnig mit leichter Bewölkung ...\"";
                }
                else if (gameManager.getDay() == 2)
                {
                    infoText.text = "Radio: \"... großes Feuer verletzt dutzende ...\"";
                }
                else if (gameManager.getDay() == 3)
                {
                    infoText.text = "Radio: \"... das Wetter für heute ... Schauer ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 4)
                {
                    infoText.text = "Radio: \"... können Popstars besser singen als tauchen? ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 5)
                {
                    infoText.text = "Radio: \"... die Währung ist stabil ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 6)
                {
                    infoText.text = "Radio: \"... schlechte Dinge geschehen überall ...\"";
                    counter++;
                }
                else if (gameManager.getDay() == 7)
                {
                    infoText.text = "Radio: \"... neue Studie sagt dumme Leute haben geringeren IQ ...\"";
                    counter++;
                }

                done = true;
            }
            else
            {
                infoText.text = "Kim: \"Ich habe bereits das Radio benutzt.\"";
            }
        }
    }

    void lookTV()
    {
        if (counter >= 2)
        {
            infoText.text = "Alex: \"Hör auf damit. Ich schau das.\"";
            return;
        }

        if (!done)
        {
            if (gameManager.getDay() > 2)
            {
                counter++;
            }

            if (gameManager.getDay() == 1)
            {
                infoText.text = "TV: \"... nun kleine Kätzchen die umherlaufen ...\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "TV: \"... großes Feuer tötet dutzende ... viele Verletzte ...\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "TV: \"... es ist nicht das wonach es aussieht, Schatz ...\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "TV: \"... neue Studie belegt ... wichtige Nachrichten sind wichtig ...\"";
            }
            else if (gameManager.getDay() == 5)
            {
                infoText.text = "TV: \"... kleines Mädchen durch Feuerwehrmann gerettet ... wird als Held gefeiert ...\"";
            }
            else if (gameManager.getDay() == 6)
            {
                infoText.text = "TV: \"... der Nobelpreis für Physik geht an ... Elbert Halsenstein ...\"";
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "TV: \"... Revolution in der IT kostet viele Jobs ...\"";
            }

            done = true;
        }
        else
        {
            infoText.text = "Kim: \"Ich habe heute genug TV geschaut.\"";
        }
    }

    void newsPaper()
    {
        if (counter >= 2)
        {
            infoText.text = "Alex: \"Warum gehst du immer so lange raus. Komm wieder rein.\"";
            return;
        }

        if (!done)
        {
            if (gameManager.getDay() > 2)
            {
                counter++;
            }

            if (gameManager.getDay() == 1)
            {
                infoText.text = "Zeitungstitel: \"Ich bin stark mit der Musik\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Zeitungstitel: \"Streit über Müllabgabe\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Zeitungstitel: \"Feuerwehrmann verletzt sich bei Rettung\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Zeitungstitel: \"Auf dem Weg zur Kirche\"";
            }
            else if (gameManager.getDay() == 5)
            {
                infoText.text = "Zeitungsinhalt: \"Gewalt in der Beziehung ... rufen sie diese Nummer an\"";
                gotNumber = true;
            }
            else if (gameManager.getDay() == 6)
            {
                infoText.text = "Zeitungstitel: \"Neuer Skatpark eröffnet\"";
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "Zeitungstitel: \"Die etwas andere Schule\"";
            }

            done = true;
        }
        else
        {
            infoText.text = "Kim: \"Ich habe mir diese Zeitung bereits angeschaut.\"";
        }
    }

    void usePhone()
    {
        if (counter >= 2)
        {
            infoText.text = "Kim: \"Wo ist der Hörer hin?.\"";
            return;
        }

        if (!done)
        {
            if (gameManager.getDay() > 2)
            {
                counter++;
            }

            if ((gameManager.getDay() == 5 ||
                gameManager.getDay() == 6 ||
                gameManager.getDay() == 7) && gotNumber)
            {
                //Ende 2
                infoText.text = "Kim: \"Helfen sie mir ... bitte ...\"";
                gameManager.showGoodEnding();
            }

            if (gameManager.getDay() == 1)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... wir sind ohne Probleme eingezogen...\"";
            }
            else if (gameManager.getDay() == 2)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... ja ... alles ist gut ... hab dich lieb ...\"";
            }
            else if (gameManager.getDay() == 3)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... uns gehts gut ... du musst dir keine Sorgen machen ...\"";
            }
            else if (gameManager.getDay() == 4)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... meine Stimme klingt komisch? ... nein alles ist ok  ...\"";
            }
            else if (gameManager.getDay() == 5)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... nein ist grad schlecht ... du kannst nicht vorbeikommen ...\"";
            }
            else if (gameManager.getDay() == 6)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... sowas kannst du nicht sagen ... wir haben viel durchgemacht ...\"";
            }
            else if (gameManager.getDay() == 7)
            {
                infoText.text = "Kim: \"... Hallo Mutti ... ich weiß es nicht ... ich habe keine Zeit ... tut mir leid ...\"";
            }

            done = true;
        }
        else
        {
            infoText.text = "Kim: \"Ich weiß nicht wen ich anrufen könnte ... vielleicht später.\"";
        }
    }

    void waterPod()
    {
        if (counter >= 2)
        {
            infoText.text = "Alex: \"Du kümmerst dich ja um die Pflanze mehr als um mich.\"";
            return;
        }

        if (!done)
        {
            if (gameManager.getDay() > 2)
            {
                counter++;
            }

            infoText.text = "Kim: \"Ich habe meine geliebte Pflanze gegossen.\"";
            GameObject.Find("Plant").GetComponent<Plant>().lastDay = gameManager.getDay();
        }
        else
        {
            infoText.text = "Kim: \"Die Pflanze ist bereits gegossen.\"";
        }
    }
}
