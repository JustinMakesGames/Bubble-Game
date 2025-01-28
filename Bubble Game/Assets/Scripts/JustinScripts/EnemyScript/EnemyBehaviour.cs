using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Transform _player;
    private Vector3 _endPosition;
    private float _timer;
    private bool _hasReachedPosition;
    public EnemyStats enemyStats;
    [SerializeField] private float playerRange;
    [SerializeField] private float maxTimeToReachPosition;
    [SerializeField] private GameObject enemyBullet;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        FindEndPosition();
        StartCoroutine(Attack());
    }

    private void Update()
    {
        LookAtPlayer();
        if (!_hasReachedPosition && _timer < maxTimeToReachPosition)
        {
            MoveToEndPosition();
        }

        else
        {
            FindEndPosition();
        }
    }

    private void LookAtPlayer()
    {
        Vector3 directionToLook = new Vector3(_player.position.x, transform.position.y, _player.position.z);

        transform.LookAt(directionToLook);
    }
    private void MoveToEndPosition()
    {
        _timer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _endPosition, enemyStats.walkSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _endPosition) < 0.05f) 
        {
            _hasReachedPosition = true;
        } 
        
    }

    private void FindEndPosition()
    {
        _endPosition = new Vector3(
            Random.Range(_player.position.x - playerRange, _player.position.x + playerRange),
            _player.position.y,
            Random.Range(_player.position.z - playerRange, _player.position.z + playerRange));

        _timer = 0;
        _hasReachedPosition = false;
    }

    public void TakeDamage(int damage)
    {
        enemyStats.health -= damage;

        if (enemyStats.health < 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(waitTime);

            Instantiate(enemyBullet, transform.position + transform.forward * 0.5f, transform.rotation);
        }
        
    }
}
