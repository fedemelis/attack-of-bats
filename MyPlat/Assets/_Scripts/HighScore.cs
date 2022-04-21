using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;
    public static int mostriUccisi = 0;
    public static int mostriUccisi2 = 0;

    private void Awake()
    {
        if (GameMaster.partita == 2)
        {
            if (mostriUccisi2 > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", mostriUccisi2);
                highScore.text = (PlayerPrefs.GetInt("BestScore")*100).ToString();
                
            }
        }
        else if (mostriUccisi > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", mostriUccisi);
            highScore.text = (PlayerPrefs.GetInt("BestScore") * 100).ToString();
        }
        highScore.text = (PlayerPrefs.GetInt("BestScore", mostriUccisi2) * 100).ToString();
        mostriUccisi = 0;
    }


    public void azzera()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        mostriUccisi = 0;
        mostriUccisi2 = 0;
        highScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}