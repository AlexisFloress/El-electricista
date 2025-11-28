using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void GoToCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
