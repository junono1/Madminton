using UnityEditor.Callbacks;
using UnityEngine;

public class movescript : MonoBehaviour
{
    public float movespeed = 5f;
    public Joystick joystick;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = joystick.Horizontal();
        float moveY = joystick.Vertical();

        Vector2 move = new Vector2(moveX, moveY);

        rb.linearVelocity = move * movespeed;
    }
}
