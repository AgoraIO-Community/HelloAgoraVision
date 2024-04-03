using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    void Update()
    {
        // Rotate the object around its local Y axis at 10 degree per second
        transform.Rotate(10 * Vector3.up * Time.deltaTime);
    }
}
