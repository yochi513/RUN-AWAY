using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ö†èd
public class goalcutin : MonoBehaviour
{
    private AudioSource audioSource;

    public string targetTag = "Player";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
                audioSource.Play();
            }
        }
    }

