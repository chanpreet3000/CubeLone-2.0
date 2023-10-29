using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void LateUpdate()
    {
        float z = Mathf.Clamp(player.transform.position.z, -3f, 3f);
        transform.position = new Vector3(player.transform.position.x, 0, z);
    }
}
