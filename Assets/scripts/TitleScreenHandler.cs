using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHandler : MonoBehaviour
{
    public string newGameScene;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("particles").SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            this.SwitchToMainScreen();
        }

    }

    // handler for game being started
    public void SwitchToMainScreen()
    {
        SceneManager.LoadScene(this.newGameScene);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
