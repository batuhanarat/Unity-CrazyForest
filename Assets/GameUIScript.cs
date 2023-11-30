using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreLabel;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text EndGameScoreLabel;
    [SerializeField] private Button PauseButton;
    [SerializeField]  private AudioSource audioSourceManager;
    [SerializeField] private AudioClip 	death;

    public void UpdateScore(int score)
    {
        ScoreLabel.text = score.ToString();
    }
    public void ShowGameOverScreen()
    {
        PlayDeathSound();
        EndGameScoreLabel.text = ScoreLabel.text;
        gameOverScreen.SetActive(true);
    }
    public void PlayDeathSound()
    {
        audioSourceManager.clip = death;
        audioSourceManager.Play();
    }


    public void ResetScore()
    {
        ScoreLabel.text = "0";
    }

   
}
