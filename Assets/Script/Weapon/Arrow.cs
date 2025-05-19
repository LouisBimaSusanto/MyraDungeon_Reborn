using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // For now just destroy enemy object
            Destroy(gameObject); //Destroy arrow
        }
    }
}
