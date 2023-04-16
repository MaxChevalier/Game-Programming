using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject[] KeyBoard;
    public GameObject[] Controller;

    // Start is called before the first frame update
    void Start()
    {
        SetKeyboard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKeyboard()
    {
        foreach (GameObject key in KeyBoard)
        {
            key.SetActive(true);
        }
        foreach (GameObject key in Controller)
        {
            key.SetActive(false);
        }
    }

    public void SetController()
    {
        foreach (GameObject key in KeyBoard)
        {
            key.SetActive(false);
        }
        foreach (GameObject key in Controller)
        {
            key.SetActive(true);
        }
    }

    void OnToggleGamepad()
    {
        SetController();
    }

    void OnToggleKeyboard()
    {
        SetKeyboard();
    }
}
