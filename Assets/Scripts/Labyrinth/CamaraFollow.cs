using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                  // si no se asigna, busca "Player" en Start
    public Vector3 offset = new Vector3(0, 0, -10);
    [Range(0.01f, 1f)] public float smoothSpeed = 0.125f;

    void Start()
    {
        if (target == null)
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            if (go != null) target = go.transform;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}