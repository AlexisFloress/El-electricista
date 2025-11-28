using UnityEngine;

public class CamaraLimiit : MonoBehaviour
{
    public GameObject player;

    public void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 16, player.transform.position.z);
    }
}
