using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBetweenOverworld : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            OverLevel();
        }

    }

    private void OverLevel()
    {
        SceneManager.LoadScene("Hive");
    }

}