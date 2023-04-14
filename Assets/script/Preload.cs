using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    public static string lvlToLoad = "lvl1";
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
        DontDestroyOnLoad(this.gameObject);
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(Preload.lvlToLoad);
    }

    public void destroy(){
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        Destroy(this.gameObject);
    }

}
