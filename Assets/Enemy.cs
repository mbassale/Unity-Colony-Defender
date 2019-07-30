using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void Start()
    {
        // Add Non Trigger Box Collider
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
