using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int d;
    AudioSource audioSource;
    bool soundon = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("firstPersone");
    }
    void Update()
    {
        float dest = Vector3.Distance(transform.position, player.transform.position);
        
        if (dest < d)
        {
            if (!soundon)
            {
                audioSource.Play();
                soundon = true;
                Debug.Log(dest);
            }
        }
        else 
        {
            audioSource.Stop();
            soundon = false;
        }
    }
}
