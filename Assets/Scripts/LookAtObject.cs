using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] GameObject _object;

    void Update()
    {
        Vector3 direction = transform.position - _object.transform.position;
        direction.y = 0f; // Clamp vertical rotation to avoid glitchy look.
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
