using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.playCoin();
            gameManager.Addscore(1);
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver();
  //          Debug.Log("Da cham");
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Water"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameManager.GameWin();
        }
    }
}
