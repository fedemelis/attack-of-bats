using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIcontrol : MonoBehaviour
{
    public static int partita = 1;

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        Score.scoreVal = 0;
        WaveCounter.waveVal = 0;
        if (GameMaster.partita == 2)
        {
            if (HighScore.mostriUccisi2 > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", HighScore.mostriUccisi2);

            }
        }
        else if (HighScore.mostriUccisi > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", HighScore.mostriUccisi);
        }
        HighScore.mostriUccisi = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Score.scoreVal = 0;
        WaveCounter.waveVal = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

