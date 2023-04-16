using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneretorsManagerLvl1 : MonoBehaviour
{
    public List<GeneratorLVL1> generatorsList = new List<GeneratorLVL1>();
    public bool OneActive = false;

    void Start()
    {
        for (int i = 0;i<transform.childCount;i++)
        {
            generatorsList.Add(transform.GetChild(i).gameObject.GetComponent<GeneratorLVL1>());
        }
        for (int i = 0;i < generatorsList.Count- 1;i++){
            GeneratorLVL1 tmp = generatorsList[i];
            int rdmIndex = Random.Range(i, generatorsList.Count);
            generatorsList[i] = generatorsList[rdmIndex];
            generatorsList[rdmIndex] = tmp;
        }
    }

    void Update()
    {
    }

    public void OnInteract()
    {
        for (int i = 0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.GetComponent<GeneratorLVL1>().OnInteract();
        }
    }



    // void OnTriggerStay2D(Collider2D other) {
    // if (other.CompareTag("generator")) {
    // }
// }
}
