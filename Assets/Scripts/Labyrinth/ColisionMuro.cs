using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionMuro : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("Colisión con muro. Reiniciando...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

}
