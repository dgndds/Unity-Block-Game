using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{

    [SerializeField] float playerMovSpeed = 2000f;
    private float playerScore = 0;

    public EventHandler<onGameOverEventArgs> onGameOver;
    public EventHandler onGameRestart;
    public class onGameOverEventArgs : EventArgs
    {
        public float UIscore;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A)) {
            //Move Left
            transform.position = new Vector3(transform.position.x + playerMovSpeed * Time.deltaTime*-1, transform.position.y,transform.position.z);

        } else if (Input.GetKey(KeyCode.D)){
            //Move Right
            transform.position = new Vector3(transform.position.x + playerMovSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        playerScore += 50 * Time.deltaTime;

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "enemy")
        {
            //Restart level
            playerScore = 0;
            onGameRestart?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "end_line")
        {
            //End level
            onGameOver?.Invoke(this, new onGameOverEventArgs { UIscore = playerScore });

        } else if(other.gameObject.tag == "despawner")
        {
            //Restart Level
            playerScore = 0;
            onGameRestart?.Invoke(this, EventArgs.Empty);
        }
    }

    public float getScore(){
        return playerScore;
    }
}
