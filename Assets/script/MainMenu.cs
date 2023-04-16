using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    private string typeText = "debugmode";
    public EventSystem eventSystem;
    public GameObject[] Panels;
    private int index = 0;
    public bool isOnGamepad = false;
    public int CurrentPanel = 0;
    public GameObject Exit;
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_WEBGL
            Destroy(Exit);
        #endif
    }

    void Update()
    {
    }

    void OnToggleGamepad()
    {
        if (!isOnGamepad)
        {
            isOnGamepad = true;
            SetSelectItem(CurrentPanel);
        }
    }

    void OnToggleKeyboard()
    {
        if (isOnGamepad)
        {
            isOnGamepad = false;
            eventSystem.SetSelectedGameObject(null);
        }
    }



    public void EXit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void loadLvl(string lvl)
    {
        Preload.lvlToLoad = lvl;
        SceneManager.LoadScene("PreloadScene");
    }

    private void UnshowPanel()
    {
        int nbtChild = Panels.Length;
        for (int i = 0; i < nbtChild; i++)
        {
            Panels[i].SetActive(false);
        }
    }

    public void mainMenuShow()
    {
        UnshowPanel();
        GameObject mainMenu = Panels[0];
        mainMenu.SetActive(true);
        if (isOnGamepad) SetSelectItem(0);
        CurrentPanel = 0;
    }

    public void CreditShow()
    {
        UnshowPanel();
        GameObject credit = Panels[1];
        credit.SetActive(true);
        if (isOnGamepad) SetSelectItem(1);
        CurrentPanel = 1;
    }

    public void SelectLvlShow()
    {
        UnshowPanel();
        GameObject selectLvl = Panels[2];
        selectLvl.SetActive(true);
        if (isOnGamepad) SetSelectItem(2);
        CurrentPanel = 2;
    }

    private void SetSelectItem(int panel)
    {
        switch (panel)
        {
            case 0:
                eventSystem.SetSelectedGameObject(Panels[0].transform.GetChild(2).gameObject);
                break;

            case 1:
                eventSystem.SetSelectedGameObject(Panels[1].transform.GetChild(4).gameObject);
                break;

            case 2:
                eventSystem.SetSelectedGameObject(Panels[2].transform.GetChild(0).gameObject);
                break;

        }
    }
}
