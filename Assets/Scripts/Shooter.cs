using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10.0f;
    [SerializeField] float projectileLifetime = 5.0f;
    [SerializeField] float fireRate = 0.1f;

    public bool isFiring;
    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously() {
        while(true) {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(fireRate);
        }
        
    }
}
