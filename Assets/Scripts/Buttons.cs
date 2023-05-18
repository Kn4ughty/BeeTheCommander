using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("GamePlay");
        //SceneManager.LoadScene (sceneName:"GamePlay");
        //SceneManager.LoadScene("GamePlay", LoadSceneMode.Additive);
    }
}
