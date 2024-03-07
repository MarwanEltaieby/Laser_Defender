using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting Sound")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    [Header("Hit Sound")]
    [SerializeField] AudioClip hitClip;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 1f;
    [Header("Crash Sound")]
    [SerializeField] AudioClip crashClip;
    [SerializeField] [Range(0f, 1f)] float crashVolume = 1f;

    private void Awake() {
        ManageSingelton();
    }

    private void ManageSingelton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip() {
        AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
    }

    public void PlayHitClip() {
        AudioSource.PlayClipAtPoint(hitClip, Camera.main.transform.position, hitVolume);
    }

    public void PlayCrashClip() {
        AudioSource.PlayClipAtPoint(crashClip, Camera.main.transform.position, crashVolume);
    }
}
