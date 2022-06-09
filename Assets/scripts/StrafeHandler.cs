using UnityEngine;
using UnityEngine.UI;

public class StrafeHandler : MonoBehaviour
{
    public long score = 0;
    public Text text;

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        text = GameObject.Find("/Canvas/Score").GetComponent<Text>();
    }

    void Update()
    {
        score++;
        text.text = ("Score: " + (score / 30 + 1));
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
        else if (!animator.GetBool("isJumping")  && Input.GetKey("space")) {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetInteger("direction", 0);
            this.playerMove(0);
        }
    }

    void playerMove(int direction)
    {
        // left
        if (direction == -1)
        {
            GameObject.Find("player").transform.position += Vector3.left * Time.deltaTime * 5;
            GameObject.Find("camera").transform.position += Vector3.left * Time.deltaTime * 5;
        }
        // right
        else if (direction == 1)
        {
            GameObject.Find("player").transform.position += Vector3.right * Time.deltaTime * 5;
            GameObject.Find("camera").transform.position += Vector3.right * Time.deltaTime * 5;
        }
        // forward
        else
        {
            GameObject.Find("player").transform.position += Vector3.forward * Time.deltaTime;
            GameObject.Find("camera").transform.position += Vector3.forward * Time.deltaTime;
        }

    }
    void resetIsJumping()
    {
        animator.SetBool("isJumping", false);
    }
}
