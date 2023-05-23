using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public CharacterController cr;
    public Transform groundCheck;
    public float radius;
    public LayerMask ground;
    public bool isGrounded;

    public float score = 0f;


    [HideInInspector]
    public bool isDead = false;

    public GameObject GameOverScreen;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float forceX = Input.GetAxis("Horizontal");
        float forceZ = Input.GetAxis("Vertical");

        velocity.y += gravity * Time.deltaTime;
        cr.Move(velocity * Time.deltaTime);

        Vector3 move = transform.right * forceX + transform.forward * forceZ;
        cr.Move(move * speed * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, ground);

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDead)
        //{
        //    velocity.y = 7;
        //    isGrounded = false;
        //}

        if (isGrounded && velocity.y < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            velocity.y = -2f;
            GameOverScreen.SetActive(true);
            isDead = true;
            Time.timeScale = 0f;
        }
        else
        {
            score += Time.deltaTime * Random.Range(10, 70);
            ScoreUI.score = Mathf.Round(score);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
