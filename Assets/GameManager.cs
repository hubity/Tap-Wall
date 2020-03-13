using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int coins;
    public Text scoreText;
    public Text scoreTextPanelGameOver;
    public Text scoreBestText;

    public Text coinTxt;

    public GameObject GameOverPanel;
    public GameObject GameOverEffetPanel;
    public GameObject panelMenu;

    public float hueValue;
    public float hueValueText;

    public SpriteRenderer[] walls;

    public Plyer player;

    public bool isPlayer;


    void Awake()
    {
        Time.timeScale = 1.0f;
        hueValue = Random.Range(0, 1f);
        hueValueText = hueValue;
    }

     void Start()
    {
        scoreBestText.text = PlayerPrefs.GetInt("bestscore").ToString();

    }
    public void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinTxt.text = coins.ToString();

        isPlayer = player.isPlay;

        if (isPlayer == true)
        {
            panelMenu.SetActive(false);

        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > PlayerPrefs.GetInt("bestscore"))
        {
            scoreBestText.text = score.ToString();
            PlayerPrefs.SetInt("bestscore", score);
        }
    }

    public void AddCoins()
    {
        coins++;
        PlayerPrefs.SetInt("coins", coins);
        coinTxt.text = coins.ToString();
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCouratine());
    }

    IEnumerator GameOverCouratine()
    {
        //GameOverEffetPanel.SetActive(false);
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.5f);
        scoreTextPanelGameOver.text = score.ToString();
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Rest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ChangeBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValueText, 0.6f, 0.8f);
        scoreText.color = Color.HSVToRGB(hueValueText, 0.6f, 0.8f);
        coinTxt.color = Color.HSVToRGB(hueValueText, 0.6f, 0.8f);
        for (int i = 0; i < walls.Length ; i++)
        {
            walls[i].color = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        }
        hueValue += 0.1f;
        hueValueText = hueValue + 0.06f;
        if (hueValue >= 1)
        {
            hueValue = 0;
            hueValueText = 0;
        }
    }

}
