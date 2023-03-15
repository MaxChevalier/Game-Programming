using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    //singleton : une seule classe inventory
    public int ItemsCount;

    public static Inventory instance;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return; // L'inventaire doit être unique !
        }
        instance = this;
    }

    public void AddItems(int count){
        ItemsCount += count;
        GameObject.Find("ItemsCountText").GetComponent<TextMeshProUGUI>().text = ItemsCount.ToString();
    }
}
