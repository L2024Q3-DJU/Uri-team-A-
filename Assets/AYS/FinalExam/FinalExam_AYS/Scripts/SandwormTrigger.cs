using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwormTrigger : MonoBehaviour
{
    public GameObject sandwormObj;
    public Animator cameraMotion;
    public Animator sandworm;
    public AudioSource earthquake;

    void Start()
    {
        cameraMotion = cameraMotion.GetComponent<Animator>();
        sandworm = sandworm.GetComponent<Animator>();
        earthquake = sandwormObj.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cameraMotion.SetTrigger("Play");
            sandworm.SetTrigger("Play");
            earthquake.Play();

        }
    }
}
