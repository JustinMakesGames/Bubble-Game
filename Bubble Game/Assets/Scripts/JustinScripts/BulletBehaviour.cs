using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float gunSpeed;
    [SerializeField] private float destroyTime;
    [SerializeField] private int damage;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * gunSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBehaviour>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
