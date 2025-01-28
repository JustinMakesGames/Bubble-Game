using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Vector3 _lookPosition;

    private bool _hasClicked;

    [SerializeField] private float bulletSpawnRange;
    [SerializeField] private GameObject bullet;
    private void Update()
    {
        LookAtMouse();
        Shoot();
        
    }

    private void LookAtMouse()
    {
        _mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            _lookPosition = hitInfo.point;
            _lookPosition.y = transform.position.y;
            transform.LookAt(_lookPosition);
        }
    }

    private void Shoot()
    {
        _hasClicked = Input.GetMouseButtonDown(0);

        if (_hasClicked)
        {
            Instantiate(bullet, transform.position + transform.forward * bulletSpawnRange, transform.rotation);
        }
        
    }
}
