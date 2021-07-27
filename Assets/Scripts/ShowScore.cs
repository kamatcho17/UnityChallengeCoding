using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    void Start()
    {
        ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
