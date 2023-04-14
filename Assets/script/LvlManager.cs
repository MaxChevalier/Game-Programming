using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LvlManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public EventSystem eventSystem;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        Inventory.instance.ActualiseMaxItems();
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        player.canMove = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        player.canMove = true;
    }

    public void QuitGame()
    {
        PauseMenu.transform.GetChild(2).gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(PauseMenu.transform.GetChild(2).transform.GetChild(2).gameObject);
    }

    public void QuitGameYes()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGameNo()
    {
        PauseMenu.transform.GetChild(2).gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(PauseMenu.transform.GetChild(1).gameObject);
    }
}
