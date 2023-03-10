using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
