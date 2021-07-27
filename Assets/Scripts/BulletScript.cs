using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{


    public GameObject hitEffect;

    private Text scoreText;

    private int score;

    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);

        if (collision.collider.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            score += Random.Range(5,15);
            PlayerPrefs.SetInt("Score", score);
            scoreText.text = score.ToString();

            if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HightScore"))
            {
                PlayerPrefs.SetInt("HightScore", PlayerPrefs.GetInt("Score"));
            }
        }

    }

}
