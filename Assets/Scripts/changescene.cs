using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Initialize()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);     //this function loads the scene that is present next in the build queue of unity.
    }
    public void Load_Helppage()
    {
        SceneManager.LoadScene("HelpPage");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IndoorNav");
        }
    }
}
