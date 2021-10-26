using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Text winText;
    public GameObject winPanel;
    bool paused = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "wins");
        winPanel.SetActive(true);
        Time.timeScale = 0;
        winText.text = other.gameObject.name + "wins";
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

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
