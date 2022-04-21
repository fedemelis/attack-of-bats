using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public static bool alive;
    public static int point;
    public static int partita = 1;

    void Start()
    {
        alive = true;
        gameOverUI.SetActive(false);
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public Transform spawnPrefab;

    public GameObject gameOverUI;


    public static void KillPlayer(Player player)
    {
        point = Score.scoreVal;
        Destroy(player.gameObject);
        gm.EndGame();
        alive = false;
        partita++;
    }



    public static void KillEnemy(Enemy enemy)
    {
        if (partita == 1)
        {
            GameMaster.gm.GetComponent<AudioSource>().Play();
            Destroy(enemy.gameObject);
            HighScore.mostriUccisi += 1;
            HighScore.mostriUccisi2 += 1;
            PlayerPrefs.SetInt("Score", HighScore.mostriUccisi);
            PlayerPrefs.SetInt("BestScore", HighScore.mostriUccisi2);
        }
        GameMaster.gm.GetComponent<AudioSource>().Play();
        Destroy(enemy.gameObject);
        HighScore.mostriUccisi += 1;
        PlayerPrefs.SetInt("Score", HighScore.mostriUccisi);
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
    }

}