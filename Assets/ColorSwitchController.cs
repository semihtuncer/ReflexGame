using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorSwitchController : MonoBehaviour
{
    public Image colorImage;
    public string[] selectableColors;

    public string selectedColorName;
    string currentColorName;

    public Text colorName1;
    public Text colorName2;

    public Text blueWinsText;
    public Text redWinsText;

    public Text winText;

    public Button blueButton;
    public Button redButton;

    public Text countdownText;
    float countdownTime = 3f;
    bool countingDown = true;

    public float lastUpdateTime = 0.0f;
    public int currentColorIndex = -1;

    int roundsToWin = 3;

    int blueWins;
    int redWins;

    bool stop;
    void Start()
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        lastUpdateTime = Time.time;
    }
    void Update()
    {
        if (countdownTime < 0 && countingDown)
        {
            blueButton.interactable = true;
            redButton.interactable = true;
            countdownText.text = "";
            countingDown = false;
            SwitchColor();
            SelectColor();
        }
        else if (countdownTime >= 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = Mathf.Round(countdownTime).ToString();
        }

        if (!countingDown)
        {
            float deltaTime = Time.time - lastUpdateTime;

            if (deltaTime > 1 && !stop)
            {
                SwitchColor();
                lastUpdateTime = Time.time;
            }
        }
        blueWinsText.text = blueWins.ToString();
        redWinsText.text = redWins.ToString();

        if (blueWins == roundsToWin || redWins == roundsToWin)
        {
            StartCoroutine(ReturnMenu());
        }
    }

    public void SwitchColor()
    {

        int nextColorIndex = Random.Range(0, selectableColors.Length);
        while (currentColorIndex == nextColorIndex)
            nextColorIndex = Random.Range(0, selectableColors.Length);

        currentColorIndex = nextColorIndex;
        currentColorName = selectableColors[currentColorIndex];

        Color currentColor = Color.clear;
        ColorUtility.TryParseHtmlString(currentColorName, out currentColor);

        colorImage.color = currentColor;
    }
    public void SelectColor()
    {
        selectedColorName = selectableColors[Random.Range(0, selectableColors.Length)];
        colorName1.text = selectedColorName;
        colorName2.text = selectedColorName;
    }

    public void OnBlueClicked()
    {
        if (currentColorName == selectedColorName)
        {
            blueWins++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            winText.GetComponent<Text>().color = new Color32(121, 121, 255, 255);
            StartCoroutine(Win("BLUE WON"));
        }
        else
        {
            blueWins--;
            StartCoroutine(Lose("BLUE LOST"));
        }
    }
    public void OnRedClicked()
    {
        if (currentColorName == selectedColorName)
        {
            redWins++;
            winText.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            winText.GetComponent<Text>().color = new Color32(255, 153, 153, 255);
            StartCoroutine(Win("RED   WON"));
        }
        else
        {
            redWins--;
            StartCoroutine(Lose("RED LOST"));
        }
    }

    public IEnumerator Win(string winner)
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        colorName1.text = "";
        colorName2.text = "";
        stop = true;
        winText.text = winner;
        yield return new WaitForSeconds(2f);
        SelectColor();
        blueButton.interactable = true;
        redButton.interactable = true;
        winText.text = "";
        stop = false;
    }
    public IEnumerator Lose(string loser)
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        colorName1.text = "";
        colorName2.text = "";
        stop = true;
        winText.text = loser;
        yield return new WaitForSeconds(2f);
        SelectColor();
        blueButton.interactable = true;
        redButton.interactable = true;
        winText.text = "";
        stop = false;
    }
    public IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(1.9f);

        SceneManager.LoadScene(0);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}