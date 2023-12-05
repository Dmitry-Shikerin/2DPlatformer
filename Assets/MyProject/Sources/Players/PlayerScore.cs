using UnityEngine;

namespace MyProject.Sources.Players
{
    public class PlayerScore : MonoBehaviour
    {
        private int _score;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Gem gem))
            {
                _score++;
            }
        }
    }
}
