using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class holeLvl3 : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = true;
            Transform player = other.gameObject.transform;
            float rotation = player.localRotation.z;
            for (int i = 0; i < 100; i++)
            {
                player.localScale = new Vector3(player.localScale.x - 0.01f, player.localScale.y - 0.01f, player.localScale.z);
                rotation += 2f;
                player.localRotation = Quaternion.Euler(0, 0, player.localRotation.z + rotation);
                yield return new WaitForSeconds(0.01f);
            }
            SceneManager.LoadScene(nextLevel);
        }
    }
}
