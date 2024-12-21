using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject door;
    [SerializeField] bool doorInterect = false;
    [SerializeField] bool doorOpen = false;
    void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    void Update()
    {
        if (doorInterect == true)
        {
            if (!doorOpen)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetTrigger("Open");
                    doorOpen = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetTrigger("Close");
                    doorOpen = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorOpen"))
        {
            anim.SetTrigger("Open");
            doorOpen = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("DoorOpen"))
        {
            doorInterect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DoorOpen"))
        {
            doorInterect = false;
            anim.SetTrigger("Close");
            doorOpen = false;
        }
    }
}
