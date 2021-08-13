using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameplayUIController : MonoBehaviour
{
    bool GamePause = false;
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnPuaseClick(bool a)
    {
        GamePause = !GamePause;
        Debug.Log(GamePause);
        if (GamePause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
