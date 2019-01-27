using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    void Start()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene(1);
    }

   public void exitGame() {
        Application.Quit();
    }

    public void goCredits() {
        SceneManager.LoadScene(2);
    }
}
