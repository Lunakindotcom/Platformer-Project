using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(playerObject);
            Destroy(enemyObject);
            GameManager manager = FindAnyObjectByType<GameManager>();
            manager.Finish();
        }
    }
}
