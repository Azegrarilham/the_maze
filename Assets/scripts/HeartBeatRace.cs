using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatRace : MonoBehaviour
{
    [SerializeField] GameObject player, endDoor;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float spacex = Math.Abs(endDoor.transform.position.x - player.transform.position.x);
        float spacez = endDoor.transform.position.z - player.transform.position.z;
        if(spacez < 30 && spacex < 10)
        {
            //Debug.Log("geting close");
            audioSource.pitch = 1.2f;
            if (spacez < 20 && spacex < 8)
            {
                audioSource.pitch = 1.5f;
            }
        }
        else audioSource.pitch = 0.9f;
       // Debug.Log(spacex + "   /  " + spacez);
    }

    IEnumerator addPitch()
    {
        yield return new WaitForSeconds(3);
        audioSource.pitch += Time.deltaTime;
    }
}
