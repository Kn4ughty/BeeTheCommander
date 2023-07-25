using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBetweenHive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            HiveLevel();
        }

    }

    private void HiveLevel()
    {
        SceneManager.LoadScene("Overworld");
    }

}