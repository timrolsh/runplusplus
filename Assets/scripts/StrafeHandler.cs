using UnityEngine;

public class StrafeHandler : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player and camera forward along its z axis 1 unit/second
        GameObject.Find("player").transform.Translate(Vector3.forward * Time.deltaTime);
        // move gameobject just forward with Z, not changing its y position
        GameObject.Find("camera").transform.position += Vector3.forward * Time.deltaTime;
        // move light with the player too
        GameObject.Find("light").transform.position += Vector3.forward * Time.deltaTime;

        // event handler for left key presses
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            animator.SetInteger("direction", -1);
        }
        // event handler for right key presses
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            animator.SetInteger("direction", 1);
        }
        // event listener for jumping
        else if (Input.GetKey("space"))
        {
            animator.SetInteger("direction", 2);
            GameObject.Find("player").transform.position += Vector3.up * Time.deltaTime * 2;
        }
        // otherwise, user is not holding down any key, and reset it back to moving forward
        else
        {
            animator.SetInteger("direction", 0);
        }
    }
}
