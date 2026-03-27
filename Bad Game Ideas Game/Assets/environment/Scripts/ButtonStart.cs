using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    
    public void Button_StartGame(){


        Debug.Log("Start button pressed");
        SceneManager.LoadScene(1);
    }

    public void Button_ConfirmQuit ()
{
    Debug.Log("Start button pressed");

    Application.Quit();
}
}
