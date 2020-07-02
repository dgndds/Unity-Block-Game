using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [SerializeField] player_movement playerScript;
    [SerializeField] Text scoreText;
    [SerializeField] bool waitForGo = true;

    // Update is called once per frame
    void Update()
    {
        if (!waitForGo)
            scoreText.text = playerScript.getScore().ToString("0");
    }

    public void setTexttoGo(){
        scoreText.text = "GO!";
        StartCoroutine(wait());
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(0.5f);
        waitForGo = false;
    }
}
