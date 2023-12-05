using MyProject.Sources.Players;
using UnityEngine;

public class GemSetActive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Debug.Log("CollisionGemScore");

            gameObject.SetActive(false);
        }
    }
}
