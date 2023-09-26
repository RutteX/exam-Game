using UnityEngine;

public class item : MonoBehaviour
{
    void FixedUpdate()
    {
        Quaternion rotationX = Quaternion.AngleAxis(1, Vector3.right);
        transform.rotation *= rotationX;
    }
}
