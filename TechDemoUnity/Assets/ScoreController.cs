using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    public TMPro.TMP_Text score;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score.text = scoreToAdd.ToString();
    }


}
