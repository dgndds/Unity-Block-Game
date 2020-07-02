using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    [SerializeField] player_movement playerScript;
    [SerializeField] final_score finalScoreScript;
    [SerializeField] score scoreScript;
    [SerializeField] GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(LevelStartWait());
        playerScript.onGameOver += gameOver;
    }

    private void gameOver(object sender, player_movement.onGameOverEventArgs e) {
        //Debug.Log("Game over");
        Cursor.visible = true;
        finalScoreScript.SetFinalScore(e.UIscore);
        gameOverUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)){
            GoToMainMenu();
        }
        
    }

    IEnumerator LevelStartWait(){
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + 0.5f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }

        Time.timeScale = 1;
        scoreScript.setTexttoGo();
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
