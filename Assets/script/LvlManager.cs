using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Inventory.instance.ActualiseMaxItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
