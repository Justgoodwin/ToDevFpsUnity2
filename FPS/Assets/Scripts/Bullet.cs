using UnityEngine;
namespace FPS
{

    public class Bullet : Ammunition
    {
        [SerializeField] private float _bulletLifeSpan = 10f;
        [SerializeField] private float _mass = 0.04f;
        [SerializeField] private LayerMask _layerMask;

        private bool _isHited;
        private float _speed;

        private float _currentDamage;

        protected override void Awake()
        {
            base.Awake();

            Destroy(gameObject, _bulletLifeSpan);

            _currentDamage = _hpBulletDamage;

            GetRigidbody.mass = _mass;
        }

        public void Intialize(float force)
        {
            Destroy(gameObject, _bulletLifeSpan);
            _speed = force;
        }

        private void FixedUpdate()
        {
            if (_isHited)
                return;

            Vector3 finalPos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit, _layerMask))
            {
                _isHited = true;
                transform.position = hit.point;

                IDamageble d = hit.collider.GetComponent<IDamageble>();
                if (d != null)
                    d.GetDamage(_hpBulletDamage);

                Destroy(gameObject, 0.3f);
            }
            else
            {
                transform.position = finalPos;
            }
        }
    }
}