using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SayText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.enabled = false;
    }

    public void ChangeText(string newText)
    {
        text.text = newText;
    }

    public IEnumerator ShowText()
    {
        text.enabled = true;
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
}
