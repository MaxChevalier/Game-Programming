using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Mob")
        {
             PlayerManager.isGameOver=true;
             gameObject.SetActive(false);
        }
    }
}
