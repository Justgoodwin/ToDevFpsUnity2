using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthBar : NetworkBehaviour
{
    [SerializeField]
    private Transform _canvas;
    [SerializeField]
    private Image _healthBar;

    public int MaxHealth = 100;

    [SyncVar(hook = "OnHealthChanged")]
    public int CurrentHealth = 100;

    private void Update()
    {
        _canvas.LookAt(Camera.main.transform.transform, Vector3.up);
    }

    public void ReciveDamage(int damage)
    {
        if (!isServer)
            return;
        if (CurrentHealth <= 0)
            CurrentHealth -=  damage;


        if (CurrentHealth <= 0)
            RpcRespawn();
    }

    private void OnHealthChanged(int health)
    {
        CurrentHealth = health;
        _healthBar.fillAmount = (float)CurrentHealth / MaxHealth;
    }

    [ClientRpc]
    private void RpcRespawn()
    {
        Debug.Log("U R Dead");
        transform.position = Vector3.up * 3f;
        CurrentHealth = 100;
    }
}
