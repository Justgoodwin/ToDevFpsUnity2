using UnityEngine;
using System.Collections;

public class TankBullets : MonoBehaviour
{

    private int _tankBulletDamage = 30;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision impactWithEnemy)
    {
        HealthBar health = impactWithEnemy.collider.GetComponent<HealthBar>();
        if (health != null)
            health.ReciveDamage(_tankBulletDamage);


        Destroy(gameObject);
    }
}
