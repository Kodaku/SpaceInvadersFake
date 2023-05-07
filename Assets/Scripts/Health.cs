using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;

    [SerializeField] bool applyCameraShake;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            if (applyCameraShake) {
                ShakeCamera();
            }
            PlayHitEffect();
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void PlayHitEffect() {
        if (hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera() {
        if (cameraShake != null) {
            cameraShake.Play();
        }
    }
}
