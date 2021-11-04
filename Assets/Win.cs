using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    //Win kinda became all my UI stuff
    public Text winText;
    public GameObject winPanel;
    bool paused = false;

    /// <summary>
    /// If character contacts the goal, displays victory panel
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "wins");
        winPanel.SetActive(true);
        Time.timeScale = 0;
        winText.text = other.gameObject.name + "wins";
    }
    /// <summary>
    /// Self explanatory
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    /// <summary>
    /// Reloads the scene
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Hit escape to bring up menu
    /// </summary>
    private void Update()
    {
        if (!paused)
        {           
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = true;
                Time.timeScale = 0;
                winPanel.SetActive(true);
                winText.text = "Paused";               
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = false;
                Time.timeScale = 1;
                winPanel.SetActive(false);
            }
        }
    }
}
