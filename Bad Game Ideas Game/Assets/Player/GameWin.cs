using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWin : MonoBehaviour
{
    public Timer timer; 
    public float time;
    public float maxTime;

    public Transform pivotLeft;
    public Transform pivotRight;

    public Image overlay;

    public GameObject player;
    public float winHeight;
    public float loseHeight;
    private bool won = false;
    private bool lost = false;
    private float winTime;

    // Start is called before the first frame update
    void Start()
    {
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.remainingtime = time;

        float angle = (time/maxTime)*90;

        pivotLeft.eulerAngles = new Vector3(0, 0, angle);
        pivotRight.eulerAngles = new Vector3(0, 0, -angle);

        if (time <= 0)
        {
            Lose();
            lost = true;
        }

        if (player.transform.position.y >= winHeight)
        {
            Win();
            winTime += Time.deltaTime;
        }

        if (player.transform.position.y <= loseHeight)
        {
            if (!lost)
            {
                time = 0;
            }
        }
    }

    void Lose()
    {
        overlay.color = new Vector4(0, 0, 0, -time);

        if (time <= -1)
        {
            SceneManager.LoadScene("Lose");
        }
    } 

    void Win()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -1;
        overlay.color = new Vector4(255, 255, 255, winTime);
        if (winTime >= 1)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
