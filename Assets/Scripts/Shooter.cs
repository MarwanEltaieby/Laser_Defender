using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float baseFireRate = 0.2f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] float minimumFireRate = 0.1f;
    AudioPlayer audioPlayer;
    Coroutine firingCoroutine;
    bool isFiring;

    private void Start() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        if(useAI) {
            isFiring = true;
        }
    }

    public bool GetIsFiring() {
        return isFiring;
    }

    public void SetIsFiring(bool isFiring) {
        this.isFiring = isFiring;
    }

    private void Update() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(Fire());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator Fire() {
        while(true) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb!=null) {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);
            float timeToNextProjectile = Random.Range(baseFireRate - fireRateVariance,
                                                        baseFireRate + fireRateVariance);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(Mathf.Clamp(timeToNextProjectile, minimumFireRate, float.MaxValue));
        }
    }

    

}
