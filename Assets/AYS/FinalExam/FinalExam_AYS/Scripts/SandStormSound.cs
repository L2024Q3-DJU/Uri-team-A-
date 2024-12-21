using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStormSound : MonoBehaviour
{
    public AudioSource sandStrom;

    // Start is called before the first frame update
    void Start()
    {
        sandStrom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PiramidTrigger"))
        {
            sandStrom.volume = 0.004f;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PiramidTrigger"))
        {
            sandStrom.volume = 0.01f;
        }
    }


}
