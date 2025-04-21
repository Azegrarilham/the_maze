using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundRmove : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine("delete");
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
