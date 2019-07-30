using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    [SerializeField] float ttl = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, ttl);
    }
}
