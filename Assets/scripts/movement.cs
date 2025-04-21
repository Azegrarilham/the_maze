using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] CharacterController controller;
    AudioSource audioSource;
    bool soundon = false;
    bool iswalking = false;
    [SerializeField] GameObject end, esc;
    public UnityEvent Gamepaused, soundpause;
    [SerializeField] AudioClip click;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movex + transform.forward * movez;
        controller.Move(move * speed * Time.deltaTime);
        if (movex != 0 || movez != 0) iswalking = true;
        else iswalking = false;

        if (iswalking && !soundon)
        {
            audioSource.Play();
            soundon = true;
        }
        else if(!iswalking)
        {
            audioSource.Stop();
            soundon = false;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            end.SetActive(true);
            Time.timeScale = 0;
            Gamepaused.Invoke();
            soundpause.Invoke();
        }
    }
    public void resetPosition()
    {
        audioSource.PlayOneShot(click);
        controller.enabled = false;
        controller.transform.position = new Vector3(3.091461f, 4.64f, -29.26536f);
        controller.enabled = true;
        esc.SetActive(false);
    }
}
