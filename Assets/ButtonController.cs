using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    GameState gameState;

    [Header("MainMenu")]
    public GameObject mainMenu;

    [Header("PlayMenu")]
    public GameObject playMenu;

    [Header("PlayGamesMenu")]
    public GameObject playGamesMenu;

    [Header("PlayTournamentMenu")]
    public GameObject playTournamentMenu;

    [Header("SettingsMenu")]
    public GameObject settingsMenu;

    [Header("AboutMenu")]
    public GameObject aboutMenu;
    public void PlayButtonClicked()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();

        playMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void PlayGamesButtonClicked()
    {
        playGamesMenu.SetActive(true);
        playMenu.SetActive(false);
    }
    public void PlayTournamentButtonClicked()
    {
        playTournamentMenu.SetActive(true);
        playMenu.SetActive(false);
    }
    public void SettingsButtonClicked()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void StaticsButtonClicked()
    {
        aboutMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Return()
    {
        playMenu.SetActive(false);
        playGamesMenu.SetActive(false);
        playTournamentMenu.SetActive(false);
        aboutMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void DiscordButton()
    {
        Application.OpenURL("https://discord.gg/B7deHqkccA");
    }

    // Games
    public void FastClickGame()
    {
        SceneManager.LoadScene(1);
        gameState.state = "Game";
    }
    public void WhiteScreenGame()
    {
        SceneManager.LoadScene(2);
        gameState.state = "Game";
    }
    public void ColorSwitchGame()
    {
        SceneManager.LoadScene(3);
        gameState.state = "Game";
    }
    public void CountDownGame()
    {
        SceneManager.LoadScene(4);
        gameState.state = "Game";
    }
}
