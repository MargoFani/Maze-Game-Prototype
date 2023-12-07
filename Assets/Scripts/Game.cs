using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float timerValue;
    [SerializeField] private Text timerView;
    [SerializeField] private Text coinView;

    [Header("Objects")]
    [SerializeField] private Player player;
    [SerializeField] private Exit exit;

    [SerializeField] private string nextLevel; 

    private float timer = 0;
    private bool gamesIsEnded;

    private string WIN_MESSAGE = "Congratulations!\nYou win!\nStart game again?";
    private string LOSE_MESSAGE = "Lose!";
    private string CONTINUE_MESSAGE = "Level complete!\nContinue?";

    private void Awake()
    {
        timer = timerValue;
        timerView.text = $"{timerValue:F1}";
        coinView.text = player.Coins.ToString();
    }

    private void Start()
    {
        player.Enable();
    }

    private void Update()
    {

        if (gamesIsEnded)
            return;

        TimerTick();
        TryCompleteLevel();
        LookAtPlayerHealth();
        LookAtPlayerInventory();

        coinView.text = player.Coins.ToString();
    }

    private void TimerTick()
    {
        timer -= Time.deltaTime;
        timerView.text = $"{timer:F1}";

        if (timer <= 0)
            Lose();
    }

    private void TryCompleteLevel()
    {        
        var flatExitPosition = new Vector2(exit.transform.position.x, exit.transform.position.z);
        var flatPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.z);
        if (flatExitPosition == flatPlayerPosition && exit.IsOpen)
            Victory();
       
    }
    
    private void LookAtPlayerHealth()
    {
        if (player.IsAlive)
            return;

        Lose();
        Destroy(player.gameObject);
    }

    private void LookAtPlayerInventory()
    {
        if (player.HasKey == false)
            return;

        exit.Open();
    }

    private void Lose()
    {
        gamesIsEnded = true;
        player.Disable();
        StateNameController.message = LOSE_MESSAGE;
        StateNameController.isAgainButton = true;
        StateNameController.nextLevel = SceneManager.GetActiveScene().name; 
        SceneManager.LoadScene("MainMenu");

        Debug.Log("Lose!");
    }

    private void Victory()
    {
        gamesIsEnded = true;
        player.Disable();
        if (nextLevel.Equals("MainMenu"))
        {
            StateNameController.message = WIN_MESSAGE;
            StateNameController.isAgainButton = true;
            StateNameController.nextLevel = "Level1";
            StateNameController.coins = 0;
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            StateNameController.message = CONTINUE_MESSAGE;
            StateNameController.coins = player.Coins;
            StateNameController.isAgainButton = false;
            StateNameController.nextLevel = nextLevel;
            SceneManager.LoadScene("MainMenu");
        }

    }


}
