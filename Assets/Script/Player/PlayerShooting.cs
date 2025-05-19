using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public GameMediator mediator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

            Vector3 originalScale = arrow.transform.localScale;

            // Ambil arah hadap player (-1 atau 1)
            float direction = Mathf.Sign(transform.localScale.x);

            // Set localScale dengan menjaga ukuran asli dan hanya ubah tanda X saja
            arrow.transform.localScale = new Vector3(Mathf.Abs(originalScale.x) * direction, originalScale.y, originalScale.z);

            // Kirim arah ke Arrow.cs
            Arrow arrowScript = arrow.GetComponent<Arrow>();
            if (arrowScript != null)
                arrowScript.SetDirection(direction);


            mediator?.Notify(gameObject, "PlayerShot");
        }
    }
}
