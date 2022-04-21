using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger = true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("KillPlayer", player);
        }
    }
}
