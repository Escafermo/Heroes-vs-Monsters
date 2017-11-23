using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    //Just plays clip, losing is handled by the Attacker that gets there first

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        audioSource.Play();
    }
      
}
