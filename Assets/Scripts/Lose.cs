using UnityEngine;

public class Lose : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Out"))
        {
            GameManager manager = FindAnyObjectByType<GameManager>();
            manager.Lost();
        }
    }
}
