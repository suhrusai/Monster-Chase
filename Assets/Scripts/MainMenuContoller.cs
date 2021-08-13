using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player1Select, player2Select,StartButton,HowToPlayInstructions,HomeButton;

    
    private void Start()
    {
        player1Select = GameObject.Find("Player 1 Select");
        player1Select.SetActive(false);
        player2Select = GameObject.Find("Player 2 Select");
        player2Select.SetActive(false);
        StartButton = GameObject.Find("Start Button");
        StartButton.SetActive(true);
        HowToPlayInstructions.SetActive(false);
        HomeButton.SetActive(false);
    }

    public void OnClickStartGame()
    {
        StartButton.SetActive(false);
        //GameObject player1Select = GameObject.Find("Player 1 Select");
        player1Select.SetActive(true);
        //GameObject player2Select = GameObject.Find("Player 2 Select");
        player2Select.SetActive(true);
        HomeButton.SetActive(true);

    }

    public void OnClickHowToPlay()
    {
        StartButton.SetActive(false);
        player1Select.SetActive(false);
        player2Select.SetActive(false);
        HowToPlayInstructions.SetActive(true);
        HomeButton.SetActive(true);
    }
    public void OnClickHomeButton()
    {
        HomeButton.SetActive(false);
        StartButton.SetActive(true);
        HowToPlayInstructions.SetActive(false);
        player1Select.SetActive(false);
        player2Select.SetActive(false);
    }
    public void PlayGame(int PlayerIndex)
    {
        SceneManager.LoadScene("Gameplay");
        GameManager.instance.CharIndex = PlayerIndex;
    }
}
