using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 30;
    [SerializeField] int score = 30;
    [SerializeField] ParticleSystem explosionVFX;
    [SerializeField] bool applyCameraShake;
    LevelManager levelManager;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = FindObjectOfType<CameraShake>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();    
        }
    }

    private void TakeDamage(int damage) {
        health -= damage;
        PlayExplosionVFX();
        ShakeCamera();
        audioPlayer.PlayHitClip();
        if (health <= 0) {
            Crash();
        }
    }

    private void Crash()
    {
        audioPlayer.PlayCrashClip();
        Destroy(gameObject);
        if(!isPlayer) {
            scoreKeeper.SetScore(score);
        } else {
            levelManager.LoadGameOver();
        }
    }

    private void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake) {
            cameraShake.Play();
        }
    }

    private void PlayExplosionVFX()
    {
        if (explosionVFX == null) {return;}
        ParticleSystem hitEffect = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(hitEffect.gameObject, explosionVFX.main.duration + explosionVFX.main.startLifetime.constantMax);
    }

    public int GetHealth() {
        return health;
    }
}
