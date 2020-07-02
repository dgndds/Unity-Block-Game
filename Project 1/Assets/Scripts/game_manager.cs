using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class game_manager : MonoBehaviour
{
    [SerializeField] player_movement playerScript;
    [SerializeField] final_score finalScoreScript;
    [SerializeField] GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        playerScript.onGameOver += gameOver;
    }

    private void gameOver(object sender, player_movement.onGameOverEventArgs e) {
        //Debug.Log("Game over");
        finalScoreScript.SetFinalScore(e.UIscore);
        gameOverUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
