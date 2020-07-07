using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public BoxCollider doorCollider;
    public int roomNum;
    public GameObject player;
    public AudioSource doorAudio;
    public AudioClip doorClip;

   // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      

    }
    private void OnTriggerEnter(Collider player)
    {
        if (player) {

            StartCoroutine(DelayedLoad());
           
            
       
            
        }
    }

    IEnumerator DelayedLoad()
    {
        //Play the clip once
        doorAudio.PlayOneShot(doorClip, 1f);

        //Wait until clip finish playing
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(roomNum);


    }


}
