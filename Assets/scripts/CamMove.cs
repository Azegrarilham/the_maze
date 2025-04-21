using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform playerRef;
    public float mousesensitivity = 4f;
    float xRotation;
    Camera m_Camera;
    [SerializeField] Animator doorhandel,openDoor;
    [SerializeField] AudioSource handeler, dooropen;
    void Awake()
    {
        m_Camera = Camera.main;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerRef.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("doorHandel"))
                {
                    handeler.Play();
                    doorhandel.SetTrigger("open");
                    openDoor.SetTrigger("opendoor");
                    dooropen.Play();
                }
                    
            }
        }

    }
}
