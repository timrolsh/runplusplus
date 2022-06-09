using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public string homeGameScene;

    void Start() {
        return;
    }

    void Update() {
        return;
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        // freezes the game
        Time.timeScale = 0f;

    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

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
