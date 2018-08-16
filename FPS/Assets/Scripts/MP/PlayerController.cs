using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private Transform _firepoint;
    [SerializeField]
    private float _moveSpeed = 2f;
    [SerializeField]
    private float _rotationSpeed = 30f;
    [SerializeField]
    private GameObject _bulletPrefab;


    private void Start()
    {
        if (isLocalPlayer)
        {
            foreach (var tanks in GetComponentsInChildren<Renderer>())
                tanks.material.color = Color.green;
        }
        else
        {
            foreach (var tanks in GetComponentsInChildren<Renderer>())
                tanks.material.color = Color.red;
        } 
            
    }
    private void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * _rotationSpeed;

        var z = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(z,0,0);

        if (Input.GetMouseButtonDown(0))
        {
            CmdFire();
        }
    }

    [Command]
    private void CmdFire()
    {
        var bullet = Instantiate(_bulletPrefab, _firepoint.position, _firepoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 150f;

        NetworkServer.Spawn(bullet);
    }
}
