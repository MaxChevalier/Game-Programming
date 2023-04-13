using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private string typeText = "debugmode";
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
    }

    public void EXit()
    {
        Application.Quit();
    }

    public void loadLvl(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    private void UnshowPanel()
    {
        int nbtChild = transform.parent.childCount;
        for (int i = 0; i < nbtChild; i++)
        {
            transform.parent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void mainMenuShow()
    {
        UnshowPanel();
        transform.parent.GetChild(0).gameObject.SetActive(true);
    }

    public void CreditShow()
    {
        UnshowPanel();
        transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    public void SelectLvlShow()
    {
        UnshowPanel();
        transform.parent.GetChild(2).gameObject.SetActive(true);
    }
}
