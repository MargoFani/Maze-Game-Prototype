using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text endMessage;
    [SerializeField] private Button againButton;
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        endMessage.text = StateNameController.message;
        if (StateNameController.isAgainButton)
        {
            againButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            againButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("Level1");
        StateNameController.coins = 0;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(StateNameController.nextLevel);
    }
}
