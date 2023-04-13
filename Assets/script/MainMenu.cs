using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene()
    }

    // Update is called once per frame
    public void EXit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("lvl1");
    }
}
