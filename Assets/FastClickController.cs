using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FastClickController : MonoBehaviour
{
    // GameState gameState;

    public RectTransform rectBlue;
    public RectTransform rectRed;

    public RectTransform winText;

    public Button blueButton;
    public Button redButton;

    public float increaseAmount;

    public Text clickerBlue;
    public Text clickerRed;

    public Text winCountBlue;
    public Text winCountRed;

    int clickedBlue = 0;
    int clickedRed = 0;

    public Text countdownText;
    float countdownTime = 3f;
    bool countingDown = true;

    int roundsToWin = 3;

    int blueWins = 0;
    int redWins = 0;
    public void Start()
    {
        //gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();

        winText.GetComponent<Text>().text = "";
        blueButton.interactable = false;
        redButton.interactable = false;

        //if(gameState.state == "Game")
        //{
        //    roundsToWin = 3;
        //}
    }
    public void Update()
    {
        if(countdownTime < 0 && countingDown)
        {
            blueButton.interactable = true;
            redButton.interactable = true;
            countdownText.text = "";
            countingDown = false;
        }
        else if (countdownTime >= 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = Mathf.Round(countdownTime).ToString();
        }

        if(blueWins == roundsToWin || redWins == roundsToWin)
        {
            StartCoroutine(ReturnMenu());
        }

        clickerBlue.text = clickedBlue.ToString();
        clickerRed.text = clickedRed.ToString();
    }
    public void ClickedBlue()
    {
        rectBlue.anchoredPosition = new Vector3(rectBlue.anchoredPosition.x, rectBlue.anchoredPosition.y + increaseAmount, 0);
        rectRed.anchoredPosition = new Vector3(rectRed.anchoredPosition.x, rectRed.anchoredPosition.y + increaseAmount, 0);
        clickedBlue++;

        if (rectBlue.anchoredPosition.y >= 400)
        {
            blueWins++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            winText.GetComponent<Text>().text = "BLUE WON";
            winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
            winCountBlue.text = blueWins.ToString();
            redButton.interactable = false;
            blueButton.interactable = false;
            StartCoroutine(Win());
        }
        if (rectRed.anchoredPosition.y <= -400)
        {
            redWins++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            winText.GetComponent<Text>().text = "RED   WON";
            winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
            winCountRed.text = redWins.ToString();
            redButton.interactable = false;
            blueButton.interactable = false;
            StartCoroutine(Win());
        }
    }
    public void ClickedRed()
    {
        rectBlue.anchoredPosition = new Vector3(rectBlue.anchoredPosition.x, rectBlue.anchoredPosition.y - increaseAmount, 0);
        rectRed.anchoredPosition = new Vector3(rectRed.anchoredPosition.x, rectRed.anchoredPosition.y - increaseAmount, 0);
        clickedRed++;

        if (rectBlue.anchoredPosition.y >= 400)
        {
            blueWins++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            winText.GetComponent<Text>().text = "BLUE WON";
            winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
            winCountBlue.text = blueWins.ToString();
            redButton.interactable = false;
            blueButton.interactable = false;
            StartCoroutine(Win());
        }
        if (rectRed.anchoredPosition.y <= -400)
        {
            redWins++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            winText.GetComponent<Text>().text = "RED   WON";
            winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
            winCountRed.text = redWins.ToString();
            redButton.interactable = false;
            blueButton.interactable = false;
            StartCoroutine(Win());
        }
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1.5f);
        clickedBlue = 0;
        clickedRed = 0;

        rectBlue.anchoredPosition = new Vector2(0,0);
        rectRed.anchoredPosition = new Vector2(0,0);

        winText.GetComponent<Text>().text = "";

        redButton.interactable = true;
        blueButton.interactable = true;
    }

    public IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(1.4f);

        SceneManager.LoadScene(0);
    }
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
