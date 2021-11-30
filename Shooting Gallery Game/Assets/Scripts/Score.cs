using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI Scoring;
    private int currentscore = 0;

    private void Start()
    {
        Scoring = Scoring.GetComponent<TextMeshProUGUI>();
    }
    public void addpoint(int point)
    {
        currentscore += point;

        Scoring.text = "Score : " + currentscore;
    }
}
