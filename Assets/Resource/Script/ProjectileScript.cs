using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Projectile[] projectiles;

    private string type;
    private float speed;
    private float damage;
    private GameObject explosionParticles;
    private GameObject modelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetProjectile(0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }

    public void SetProjectile (int projectileIndex)
    {
        //Sets internal variables to those from the array
        type = projectiles[projectileIndex].name;
        speed = projectiles[projectileIndex].speed;
        damage = projectiles[projectileIndex].damage;
        explosionParticles = projectiles[projectileIndex].explosionParticles;

        Instantiate(projectiles[projectileIndex].projectilePrefab, transform.position, transform.rotation, transform);
        gameObject.name = "Projectile (" + type + ")";
    }

    private void OnCollisionEnter(Collision collision)
    {
        TankScript tank = collision.gameObject.GetComponent<TankScript>();
        if (tank != null)
        {
            tank.ChangeHealth(-damage);
        }
        Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
