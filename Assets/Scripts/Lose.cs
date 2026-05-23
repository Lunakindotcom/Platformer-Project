using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject enemyObject;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(enemyObject);
            GameManager manager = FindAnyObjectByType<GameManager>();
            manager.Lost();
        }
    }
}
