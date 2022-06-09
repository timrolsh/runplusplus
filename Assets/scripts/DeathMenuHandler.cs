using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuHandler : MonoBehaviour
{
    public GameObject deathMenu;
    public string homeGameScene;
    public string mainGameScene;

    void Start() {
        return;
    }

    void Update() {
        return;
    }

    public void pause()
    {
        deathMenu.SetActive(true);
        // freezes the game
        Time.timeScale = 0f;

    }
    public void resume()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(this.mainGameScene);

    }

    public void goToHomeScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(this.homeGameScene);
    }

    public void quit()
    {
        Application.Quit();
    }
}
