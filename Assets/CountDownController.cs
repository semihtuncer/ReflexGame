using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public Text countDownText1;
    public Text countDownText2;

    public Text blueCountText;
    public Text redCountText;

    public Text blueWinText;
    public Text redWinText;

    public Text blueRangeText;
    public Text redRangeText;

    public Button blueButton;
    public Button redButton;

    public Text winText;

    float blueCount;
    float redCount;

    int roundsToWin = 3;

    float blueRange;
    float redRange;

    public GameObject closer1;
    public GameObject closer2;

    int blueWins;
    int redWins;

    bool blueClicked = false;
    bool redClicked = false;

    float randomNumber;
    void Start()
    {
        blueButton.interactable = true;
        redButton.interactable = true;
        closer1.SetActive(false);
        closer2.SetActive(false);
        RandomFloat();
    }

    void Update()
    {
        if (!blueClicked)
            blueCount += Time.deltaTime;

        if (!redClicked)
            redCount += Time.deltaTime;

        blueCountText.text = blueCount.ToString("f2");
        redCountText.text = redCount.ToString("f2");

        blueWinText.text = blueWins.ToString();
        redWinText.text = redWins.ToString();

        if (blueWins == roundsToWin || redWins == roundsToWin)
        {
            StartCoroutine(ReturnMenu());
        }
    }

    public void OnBlueClicked()
    {
        blueClicked = true;

        blueRange = Mathf.Abs(randomNumber - blueCount);
        closer1.SetActive(false);

        if(randomNumber - blueCount < 0)
            blueRangeText.text = "-" + blueRange.ToString("f2");
        if (randomNumber - blueCount >= 0)
            blueRangeText.text = "+" + blueRange.ToString("f2");

        if (blueClicked && redClicked)
        {
            if (blueRange < redRange)
            {
                blueWins++;
                winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
                winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
                StartCoroutine(Win("BLUE WON"));
            }
            if (blueRange > redRange)
            {
                redWins++;
                winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
                winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
                StartCoroutine(Win("RED   WON"));
            }
            if (blueRange == redRange)
            {
                winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
                winText.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                StartCoroutine(Win("TIE"));
            }
        }
    }

    public void OnRedClicked()
    {
        redClicked = true;

        redRange = Mathf.Abs(randomNumber - redCount);
        closer2.SetActive(false);

        if (randomNumber - redCount < 0)
            redRangeText.text = "-" + redRange.ToString("f2");
        if (randomNumber - redCount >= 0)
            redRangeText.text = "+" + redRange.ToString("f2");

        if (blueClicked && redClicked)
        {
            if (blueRange < redRange)
            {
                blueWins++;
                winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
                winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
                StartCoroutine(Win("BLUE WON"));
            }
            if (blueRange > redRange)
            {
                redWins++;
                winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
                winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
                StartCoroutine(Win("RED   WON"));
            }
            if (blueRange == redRange)
            {
                winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
                winText.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                StartCoroutine(Win("TIE"));
            }
        }
    }

    public IEnumerator Win(string winner)
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        winText.text = winner;
        yield return new WaitForSeconds(5);
        winText.text = "";
        blueButton.interactable = true;
        redButton.interactable = true;
        blueCount = 0;
        redCount = 0;
        blueRangeText.text = "";
        redRangeText.text = "";
        blueClicked = false;
        redClicked = false;
        RandomFloat();
    }

    void RandomFloat()
    {
        randomNumber = Random.Range(5f, 20f);
        countDownText1.text = randomNumber.ToString("F1") + "0";
        countDownText2.text = randomNumber.ToString("F1") + "0";
        closer1.SetActive(false);
        closer2.SetActive(false);
        StartCoroutine(CloseCounter());
    }
    public IEnumerator CloseCounter()
    {
        yield return new WaitForSeconds(4);

        closer1.SetActive(true);
        closer2.SetActive(true);
    }

    public IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(4.9f);

        SceneManager.LoadScene(0);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
