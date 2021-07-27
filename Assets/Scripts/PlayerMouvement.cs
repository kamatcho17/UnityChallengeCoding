using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float angle;

    public Rigidbody2D rb;
    public Camera cam;

    [SerializeField] GameObject enemys;

    Vector2 mouvement;
    Vector2 mousePos;
    Vector2 lookDir;


    // Update is called once per frame
    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (enemys.transform.childCount == 0)
        {
            PlayerPrefs.SetInt("PlayerWin", 1);
            SceneManager.LoadScene(2);
        }
        if(PlayerPrefs.GetInt("Score") < 0) 
        { 
            PlayerPrefs.SetInt("PlayerWin", -1);
            SceneManager.LoadScene(2);
        }

    }

    private void FixedUpdate()
    {
        // Move the Player using keyboard
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.deltaTime);

        // Rotate the player using Mouse
        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
