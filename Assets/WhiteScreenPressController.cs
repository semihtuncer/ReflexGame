using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhiteScreenPressController : MonoBehaviour
{
    //GameState gameState;

    public GameObject whiteScreen;
    public bool isWhite = false;

    public Text blueWinsText;
    public Text redWinsText;

    public Text winText;

    public Button blueButton;
    public Button redButton;

    public float randTime;
    public float startTime = 0.0f;

    bool canOpen = true;

    int roundsToWin = 3;

    int bluePoint;
    int redPoint;
    void Start()
    {
        randTime = Random.Range(3, 8);

        //gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();

        startTime = Time.time;

        //if (gameState.state == "Game")
        //{
        //    roundsToWin = 3;
        //}
    }
    void Update()
    {
        if (((randTime -= Time.deltaTime) < 0) && canOpen)
        {
            whiteScreen.SetActive(true);
            isWhite = true;
        }

        blueWinsText.text = bluePoint.ToString();
        redWinsText.text = redPoint.ToString();

        if (bluePoint == roundsToWin || redPoint == roundsToWin)
        {
            StartCoroutine(ReturnMenu());
        }
    }

    public void OnBlueClicked()
    {
        if (isWhite)
        {
            bluePoint++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
            StartCoroutine(GetPoint("BLUE WON"));
        }
        else
        {
            bluePoint--;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
            StartCoroutine(RemovePoint("BLUE LOST"));
        }
    }
    public void OnRedClicked()
    {
        if (isWhite)
        {
            redPoint++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
            StartCoroutine(GetPoint("RED   WON"));
        }
        else
        {
            redPoint--;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
            StartCoroutine(RemovePoint("RED  LOST"));
        }
    }

    public IEnumerator GetPoint(string winner)
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        winText.text = winner;
        yield return new WaitForSeconds(3f);
        whiteScreen.SetActive(false);
        blueButton.interactable = true;
        redButton.interactable = true;
        randTime = Random.Range(3, 8);
        isWhite = false;
        winText.text = "";
    }

    public IEnumerator RemovePoint(string loser)
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        canOpen = false;
        winText.text = loser;
        yield return new WaitForSeconds(3f);
        canOpen = true;
        blueButton.interactable = true;
        redButton.interactable = true;
        winText.text = "";
        randTime = Random.Range(3, 8);
    }

    public IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(2.9f);

        SceneManager.LoadScene(0);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
