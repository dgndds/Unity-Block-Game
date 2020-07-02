using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [SerializeField] player_movement playerScript;
    [SerializeField] Text scoreText;
    [SerializeField] bool waitForGo = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitForGo)
            scoreText.text = playerScript.getScore().ToString("0");
        
    }

    public void setTexttoGo(){
        
        Debug.Log("giriyor");
        scoreText.text = "GO!";
        StartCoroutine(wait());
        
        // StartCoroutine(setTexttoGo());
        // yield return new WaitForSeconds(1);
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(0.5f);
        waitForGo = false;
    }
}
