using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{

    GameObject scoreGameObject,winobject,gameOverObject;
    // Start is called before the first frame update
    private void Start()
    {
        scoreGameObject = GameObject.Find("Score");
        winobject = GameObject.Find("Win");
        gameOverObject = GameObject.Find("GameOver");

        if (PlayerPrefs.GetInt("PlayerWin") == 1)
        {
            gameOverObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("PlayerWin") == -1)
        {
            scoreGameObject.SetActive(false);
            winobject.SetActive(false);
        }
    }
    public void RestartGame()
    {
        scoreGameObject.SetActive(true);
        winobject.SetActive(true);
        gameOverObject.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
