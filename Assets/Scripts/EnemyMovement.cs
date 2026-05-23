using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 4f;
    public GameObject Target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager gm = FindAnyObjectByType<GameManager>();
            gm.Lost();
        }
    }
}