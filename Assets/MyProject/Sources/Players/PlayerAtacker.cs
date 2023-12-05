using UnityEngine;

public class PlayerAtacker : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(_damage);
        }
    }
}
