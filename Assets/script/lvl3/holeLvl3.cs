using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeLvl3 : MonoBehaviour
{
    public string nextLevel;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        if (!active) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().canMove = false;
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = true;
            Transform player = other.gameObject.transform;
            float rotation = player.localRotation.z;
            for (int i = 0; i < 100; i++)
            {
                if (player.localScale.x > 0.01f)
                {
                    player.localScale = new Vector3(player.localScale.x - 0.01f, player.localScale.y - 0.01f, player.localScale.z);
                }
                rotation += 2f;
                player.localRotation = Quaternion.Euler(0, 0, player.localRotation.z + rotation);
                yield return new WaitForSeconds(0.01f);
            }
            if (nextLevel == "death")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Death();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(nextLevel);
                Inventory.instance.SaveItems();
            }
        }
    }
}
