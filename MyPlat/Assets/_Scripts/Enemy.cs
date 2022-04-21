using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject blood;
    public int maxHealt;
    public int currentHealth;
    public int enemyDmg;
    public Player _player;

    private void Start()
    {
        maxHealt = 100;
        currentHealth = maxHealt;
        enemyDmg = 20;

    }

    private void Update()
    {
        deathCk();
    }


    void damageEnemy(int damage)
    {
        currentHealth -= damage;
    }


    public void deathCk()
    {
        if (currentHealth <= 0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Score.scoreVal += 100;
            GameMaster.KillEnemy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player _player = collision.collider.GetComponent<Player>();
        if (_player != null)
        {
            _player.playerDamage(enemyDmg);
            damageEnemy(999999);
        }
    }



}
