using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera player;
    public Rigidbody playerGameObject;
    float yRot;

    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        yRot = player.transform.rotation.y;
        playerGameObject.rotation *= Quaternion.Euler(0f, yRot, 0f);
    }
}
