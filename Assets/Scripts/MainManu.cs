using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void CreditGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        GameManager.score = 0;
        GameManager.turnCounter = 0;
        GameManager.sumScore = 0;
        SceneManager.LoadScene(0);
    }
}
