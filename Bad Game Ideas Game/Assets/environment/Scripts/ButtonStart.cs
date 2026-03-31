using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public string scene;
    public void Button_StartGame(){


        Debug.Log("Start button pressed");
        SceneManager.LoadScene(scene);
    }

    public void Button_ConfirmQuit ()
{
    Debug.Log("Start button pressed");

    Application.Quit();
}
}
