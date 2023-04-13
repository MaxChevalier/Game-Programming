using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ExitLvl1 : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public AudioSource introAudioSource;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.canMove = false;
            player.Movement = Vector2.down;
            player.animator.SetInteger("mouvement", 2);
            introAudioSource.Stop();
            vcam.Follow = null;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("MainMenu");
        }
    }

}
