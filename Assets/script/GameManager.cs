using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public EventSystem eventSystem;
    public GameObject ConfirmQuit;
    public Preload preload;
    public GameObject InteractUI;
    public GameObject DeathMenu;
    public GameObject LoadingScreen;
    private GameObject LoadingCircle;
    // Start is called before the first frame update
    void Start()
    {
        InteractUI = GameObject.Find("InteractInfo");
        InteractUI.SetActive(false);
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(false);
        LoadingCircle = LoadingScreen.transform.GetChild(0).gameObject;
        LoadingCircle.SetActive(false);
        
        SceneManager.sceneLoaded += OnSceneLoaded; // effectue la fonction OnSceneLoaded quand une scene est chargée
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadingCircle.SetActive(false);
        LoadingScreen.GetComponent<Animator>().SetBool("isLoading", false);
    }

    // lance la coroutinede changement de scene
    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncLoadScene(sceneName));
    }

    // charge la scene derriere un écran de chargement
    IEnumerator AsyncLoadScene(string sceneName)
    {
        LoadingScreen.GetComponent<Animator>().SetBool("isLoading", true);
        yield return new WaitForSeconds(2f);
        LoadingCircle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        GameObject.Find("player").GetComponent<Player>().canMove = false;
        eventSystem.SetSelectedGameObject(PauseMenu.transform.GetChild(1).gameObject);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        GameObject.Find("player").GetComponent<Player>().canMove = true;
        QuitGameNo();
    }

    public void QuitGame()
    {
        ConfirmQuit.SetActive(true);
        eventSystem.SetSelectedGameObject(ConfirmQuit.transform.GetChild(2).gameObject);
    }

    public void QuitGameYes()
    {
        Time.timeScale = 1;
        preload.destroy();
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene("MainMenu");
    }

    public void QuitGameNo()
    {
        ConfirmQuit.SetActive(false);
        eventSystem.SetSelectedGameObject(PauseMenu.transform.GetChild(1).gameObject);
    }

    public void Death()
    {
        GameObject.Find("player").GetComponent<Player>().canMove = false;
        GameObject.Find("player").GetComponent<Player>().Movement = Vector2.zero;
        StartCoroutine(ShowDeathMenu());
    }

    IEnumerator ShowDeathMenu()
    {
        yield return new WaitForSeconds(1f);
        DeathMenu.SetActive(true);
        Time.timeScale = 0;
        eventSystem.SetSelectedGameObject(DeathMenu.transform.GetChild(1).gameObject);
    }

    public void Restart()
    {
        Inventory.instance.ReloadItems();
        Time.timeScale = 1;
        DeathMenu.SetActive(false);
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(SceneManager.GetActiveScene().name);
    }
}
