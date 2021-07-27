using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHightScore : MonoBehaviour
{
    [SerializeField] Text hightScoreText;
    void Start()
    {
        hightScoreText.text = PlayerPrefs.GetInt("HightScore").ToString();
    }
}
