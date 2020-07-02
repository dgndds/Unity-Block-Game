using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToCredits(){
        SceneManager.LoadScene("credits");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void CloseGame(){
        Application.Quit();
    }
}
