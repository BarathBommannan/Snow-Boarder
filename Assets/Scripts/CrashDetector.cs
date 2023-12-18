using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField]float reloadtime =2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip CrashSFX;
    bool hasCrashed=false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && hasCrashed==false)
        {
            hasCrashed=true;
            FindObjectOfType<PlayerController>().disableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashSFX);
            Invoke("ReloadScene",reloadtime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

