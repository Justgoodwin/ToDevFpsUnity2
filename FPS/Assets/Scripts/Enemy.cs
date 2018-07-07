using UnityEngine;
namespace FPS
{

    public class Enemy : BaseObjectScene, IDamageble
    {
        [SerializeField] private float _hp = 100f;
        private bool _isDead = false;
        private float _step = 2f;

        public void GetDamage(float damage)
        {
            _hp -= damage;
            Color = Random.ColorHSV();
        }

        public void Update()
        {
            if (_isDead)
            {
                Color color = GetMaterial.color;
            }
        }
    }
}