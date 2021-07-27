using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    Transform target;

    private NavMeshAgent agent;
    private Text scoreText;
    private int score;
    private bool canDamage = true;
    private float counter = 0f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        score = PlayerPrefs.GetInt("Score");
        if (collision.collider.transform.tag == "Player" && canDamage)
        {
            canDamage = false;
  
            score -= Random.Range(0, 10);
            PlayerPrefs.SetInt("Score", score);
            scoreText.text = score.ToString();
        }
    }

    private void FixedUpdate()
    {
        if (canDamage == false)
        {
            counter += Time.fixedDeltaTime;
            if (counter >= 1)
            {
                counter = 0;
                canDamage = true;
            }
        }
    }

}
