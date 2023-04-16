using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LvlManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Inventory.instance.ActualiseMaxItems();
    }
}
