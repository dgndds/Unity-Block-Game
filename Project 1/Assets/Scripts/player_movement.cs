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
    public class onGameOverEventArgs : EventArgs
    {
        public float UIscore;
    }

    public

    // Start is called before the first frame update
    void Start()
    {
        //rigidb = GetComponent<Rigidbody>();
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
            restartLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "end_line")
        {
            //End level
            // gameOver();
            onGameOver?.Invoke(this, new onGameOverEventArgs { UIscore = playerScore });

        } else if(other.gameObject.tag == "despawner")
        {
            restartLevel();
        }
    }

    public float getScore(){
        return playerScore;
    }
    
    private void restartLevel(){
        playerScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
