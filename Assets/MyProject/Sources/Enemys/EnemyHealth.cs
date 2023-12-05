using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 1;

    public void TakeDamage(int damage) => 
        _currentHealth -= damage;
}
