using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Board : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(float score)
    {
        scoreText.text = $"Score: {score}";
    }
}
