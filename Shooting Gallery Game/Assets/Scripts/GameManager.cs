using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int greenctr, bluectr, redctr;
    public GameObject greenobject, redobject, blueobject;
    public GameObject greenposition, redposition, blueposition;

    //timer
    public float timeRemaininginSeconds = 10;
    private bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    //reload scene button
    public GameObject Reloadscene, Quit;


    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //detect targets
        greenctr = GameObject.FindGameObjectsWithTag("Green").Length;
        bluectr = GameObject.FindGameObjectsWithTag("Blue").Length;
        redctr = GameObject.FindGameObjectsWithTag("Red").Length;

        if (greenctr == 0)
        {
            SpawnGreen();
        }
        if (greenctr == 0)
        {
            SpawnBlue();
        }
        if (greenctr == 0)
        {
            SpawnRed();
        }

        //timer
        if (timerIsRunning)
        {
            if (timeRemaininginSeconds > 0)
            {
                timeRemaininginSeconds -= Time.deltaTime;
                DisplayTime(timeRemaininginSeconds);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaininginSeconds = 0;
                timerIsRunning = false;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Reloadscene.SetActive(true);
                Quit.SetActive(true);
            }
        }
    }

    // Spawns object according to if they are not there anymore
    void SpawnGreen()
    {
        Instantiate(greenobject, greenposition.transform.position, greenposition.transform.rotation);
    }

    void SpawnBlue()
    {
        Instantiate(blueobject, blueposition.transform.position, blueposition.transform.rotation);

    }

    void SpawnRed()
    {
        Instantiate(redobject, redposition.transform.position, redposition.transform.rotation);

    }

    //displaystime
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    //reload scene
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
}
