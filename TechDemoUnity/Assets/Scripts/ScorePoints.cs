using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{

    public TMPro.TMP_Text points;

    void Start()
    {
        points.text = "0";
    }

    public void SetPoints(int pointsToSet)
    {
        points.text = pointsToSet.ToString();
    }


}
