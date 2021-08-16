using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameplayUIController : MonoBehaviour
{
    bool GamePause = false;
    [SerializeField]
    private Sprite PauseImg,ResumeImg;
    [SerializeField]
    private GameObject PlayPauseButton;
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
	    PlayPauseButton.GetComponent<Image>().sprite=ResumeImg;
            Time.timeScale = 0;
        }
        else
        {
	    PlayPauseButton.GetComponent<Image>().sprite=PauseImg;
            Time.timeScale = 1;
        }
    }
}
