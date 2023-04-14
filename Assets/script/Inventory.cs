using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    //singleton : une seule classe inventory
    public int ItemsCount;
    public int TotItems = 0;
    private int saveItemsCount;
    private int saveTotItems = 0;



    public static Inventory instance;

    private void Awake(){
        if(instance != null){
            Destroy(gameObject);
            return; // L'inventaire doit être unique !
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ActualiseMaxItems(){
        TotItems += GameObject.FindGameObjectsWithTag("Item").Length;
    }

    public void AddItems(int count){
        ItemsCount += count;
        GameObject.Find("ItemsCountText").GetComponent<TextMeshProUGUI>().text = ItemsCount.ToString();
    }

    public void SaveItems(){
        saveItemsCount = ItemsCount;
        saveTotItems = TotItems;
    }

    public void ReloadItems(){
        ItemsCount = saveItemsCount;
        TotItems = saveTotItems;
        GameObject.Find("ItemsCountText").GetComponent<TextMeshProUGUI>().text = ItemsCount.ToString();
    }
}