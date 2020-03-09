using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Projectile
{
    public string name;
    public float damage;
    public float speed;
    public GameObject explosionParticles;
    public GameObject effectObject;
    public GameObject projectilePrefab;
}
