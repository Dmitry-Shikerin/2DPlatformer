using UnityEngine;

namespace MyProject.Sources.Players
{
    [RequireComponent(typeof(PlayerAnimation))]
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _currentHealth;

        private PlayerAnimation _playerAnimation;
        
        private void Awake() => 
            _playerAnimation = GetComponent<PlayerAnimation>();

        public void TakeDamage()
        {
            _currentHealth--;
            _playerAnimation.PlayHurt();
        }

        public void AddHealth(int count) => 
            _currentHealth += count;
    }
}
