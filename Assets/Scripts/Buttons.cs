using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Menu");
        //SceneManager.LoadScene (sceneName:"Menu");
        //SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
