using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputEventsMenu : MonoBehaviour {
    public void onClickStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void onClickLeaveGame()
    {
        Application.Quit();
    }
}
