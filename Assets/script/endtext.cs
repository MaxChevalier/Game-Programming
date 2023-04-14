using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endtext : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText(){
        yield return new WaitForSeconds(1f);
        Text1();
        yield return new WaitForSeconds(5f);
        NoText();
        yield return new WaitForSeconds(1f);
        Text3();
        yield return new WaitForSeconds(2f);
        NoText();
        yield return new WaitForSeconds(1f);
        Text4();
        yield return new WaitForSeconds(2f);
        NoText();
        yield return new WaitForSeconds(1f);
        Text5();
        yield return new WaitForSeconds(2f);
        NoText();
        yield return new WaitForSeconds(1f);
        Text6();
        yield return new WaitForSeconds(4f);
        NoText();
        yield return new WaitForSeconds(1f);
        float wintingTime = Text7();
        yield return new WaitForSeconds(wintingTime);
        NoText();
        yield return new WaitForSeconds(1f);
        Text8();
        yield return new WaitForSeconds(3f);
        NoText();
        yield return new WaitForSeconds(1f);
        Text9();
        yield return new WaitForSeconds(3f);
    }

    public void BackToMenu(){
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene("Menu");
    }

    void NoText(){
        text.text = "";
    }

    void Text1()
    {
        text.text = "You have found the exit\nYou run out of the building";
        audioSource.PlayOneShot(audioClip[0]);
    }

    void Text3()
    {
        text.text = "You are free";
        audioSource.PlayOneShot(audioClip[1]);
    }

    void Text4()
    {
        text.text = "You are safe";
        audioSource.PlayOneShot(audioClip[2]);
    }

    void Text5()
    {
        text.text = "You are alive";
        audioSource.PlayOneShot(audioClip[3]);
    }

    void Text6()
    {
        text.text = "you will report to the authority what you have saw";
        audioSource.PlayOneShot(audioClip[4]);
    }

    float Text7()
    {
        if (Inventory.instance.ItemsCount > Inventory.instance.TotItems*0.9)
        {
            text.text = "The evidence you have recovered is enough for the authority to find and arrest the culprits and put an end to all of this horror.";
            audioSource.PlayOneShot(audioClip[5]);
            return 10f;
        }else if (Inventory.instance.ItemsCount > Inventory.instance.TotItems*0.6)
        {
            text.text = "You will put your evidence. But this is not enough and a small investigation is opened which will not succeed.";
            audioSource.PlayOneShot(audioClip[6]);
            return 10f;
        }else{
            text.text = "But you don't have enough evidence and nobody believes you";
            audioSource.PlayOneShot(audioClip[7]);
            return 4f;
        }
    }

    void Text8()
    {
        text.text = Inventory.instance.ItemsCount + " evidence collected";
    }

    void Text9()
    {
        text.text = "Thank you for playing";
        audioSource.PlayOneShot(audioClip[8]);
    }
}
