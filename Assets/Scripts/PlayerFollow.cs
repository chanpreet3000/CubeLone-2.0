using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
