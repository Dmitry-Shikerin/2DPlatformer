using System.Collections;
using MyProject.Sources.Players;
using UnityEngine;

namespace MyProject.Sources.Enemys
{
    public class EnemyAtacker : MonoBehaviour
    {
        [SerializeField] private float _attackSped = 2f;

        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        private void Awake() => 
            _waitForSeconds = new WaitForSeconds(_attackSped);

        private void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out PlayerHealth playerHealth))
            {
                DealDamage(playerHealth);
            }
        }
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out PlayerHealth playerHealth))
            {
                StopDealDamage();
            }
        }

        private IEnumerator DamageRoutine(PlayerHealth playerHealth)
        {
            while (true)
            {
                playerHealth.TakeDamage();
                yield return _waitForSeconds;
            }
        }

        private void DealDamage(PlayerHealth playerHealth)
        {
            if(_coroutine != null)
                return;

            _coroutine = StartCoroutine(DamageRoutine(playerHealth));
        }
        
        private void StopDealDamage()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}