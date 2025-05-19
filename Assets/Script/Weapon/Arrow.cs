using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public float direction = 1f;

    public void SetDirection(float dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.instance.NotifyAll("EnemyHit");
            Destroy(collision.gameObject); // For now just destroy enemy object
            Destroy(gameObject); //Destroy arrow
        }
    }
}
