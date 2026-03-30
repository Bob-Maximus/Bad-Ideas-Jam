using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player1 != null && player2 != null)
        {
            Vector3 midpoint = (player1.position + player2.position) / 2f;
            Vector3 targetPosition = midpoint + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
