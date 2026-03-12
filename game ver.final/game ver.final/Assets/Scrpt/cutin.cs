using UnityEngine;
using System.Collections;

//ö†èd

public class cutin : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
         audioSource.Play();
       }
    }

