using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField] List<GameObject> sounds;
    void Start()
    {
        InvokeRepeating("spawnSound", 20, 40);
    }

    void spawnSound()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-15, 15);
        int index = Random.Range(0, sounds.Count);
        Instantiate(sounds[index], new Vector3(x, 2, z), sounds[index].transform.rotation);
    }
}
