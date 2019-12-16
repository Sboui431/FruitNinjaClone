using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

   //UI-User Interface -Benutzeroberfläche
   [Header("Score Elements")]
    public int score;
    public Text scoreText;

    public int highscore;
    public Text highscoreText;

    [Header("GameOver Elements")]
    public GameObject gameOverPanel;
    [Header("Sound")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        //Highscore auf 0 setzen .Für Testzweke
        // PlayerPrefs.SetInt("Highscore", 0);
        GetHighscore();
    }

    private void GetHighscore()
    {
        highscore=PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best : " + highscore;
    }

    public void IncreaseScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best : " +  score.ToString();
        }
    }
    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        Debug.Log("Bomb Hit");
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = "0";
        gameOverPanel.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        GetHighscore();

        Time.timeScale = 1;
    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
