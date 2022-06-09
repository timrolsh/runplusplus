using UnityEngine;
using UnityEngine.UI;

public class StrafeHandler : MonoBehaviour
{
    public long score = 0;
    public Text scoreObject;
    public Text highScoreObject;

    public Animator animator;
    public GameObject deathMenu;
    public AudioSource boingSoundEffect;
    public AudioSource deathSoundEffect;
    void Start()
    {
        Time.timeScale = 1f;
        scoreObject = GameObject.Find("/Canvas/Score").GetComponent<Text>();
        highScoreObject = GameObject.Find("/Canvas/HighScore").GetComponent<Text>();
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }
    }

    void Update()
    {
        if (Time.timeScale != 0f)
        {
            int score = (int)(this.score / 30) + 1;
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
            this.score++;
            scoreObject.text = ("Score: " + score);
            highScoreObject.text = ("High Score: " + PlayerPrefs.GetInt("highScore"));
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                animator.SetInteger("direction", -1);
                this.playerMove(-1);
            }
            else if (Input.GetKey("d") || Input.GetKey("right"))
            {
                animator.SetInteger("direction", 1);
                this.playerMove(1);
            }
            else if (!animator.GetBool("isJumping") && Input.GetKey("space"))
            {
                animator.SetBool("isJumping", true);
                boingSoundEffect.Play();

            }
            else
            {
                animator.SetInteger("direction", 0);
                this.playerMove(0);
            }
            // handler for when character dies
            if (GameObject.Find("player").transform.position.y <= -5)
            {
                deathMenu.SetActive(true);
                // freezes the game
                Time.timeScale = 0f;
                // play sound effect
                deathSoundEffect.Play();
            }
            // always move forward
            else
            {
                GameObject.Find("player").transform.position += Vector3.forward * Time.deltaTime * 8;
                GameObject.Find("camera").transform.position += Vector3.forward * Time.deltaTime * 8;
            }
        }
    }

    void playerMove(int direction)
    {
        // left
        if (direction == -1)
        {
            GameObject.Find("player").transform.position += Vector3.left * Time.deltaTime * 8;
            GameObject.Find("camera").transform.position += Vector3.left * Time.deltaTime * 8;
        }
        // right
        else if (direction == 1)
        {
            GameObject.Find("player").transform.position += Vector3.right * Time.deltaTime * 8;
            GameObject.Find("camera").transform.position += Vector3.right * Time.deltaTime * 8;
        }

    }
    void resetIsJumping()
    {
        animator.SetBool("isJumping", false);
    }
}
