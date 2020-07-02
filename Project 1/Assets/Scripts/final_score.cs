using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class final_score : MonoBehaviour
{

    [SerializeField] Text scoreText;

    public void SetFinalScore(float score){
        scoreText.text = "Score: " + score.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
