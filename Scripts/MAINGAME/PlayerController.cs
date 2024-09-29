using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movementDirection;
    private Rigidbody rb;
    private Vector3 startPosition;

    public Animator animator;

    void Start()
    {
        startPosition = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical"); 

        movementDirection = new Vector3(-moveX, 0f, -moveZ);
        movementDirection.Normalize();

        if (movementDirection.magnitude > 0.5f)
        {
            animator.SetBool("IsMoveing", true);
            RotateTowardsMovementDirection();
        }
        else
        {
            animator.SetBool("IsMoveing", false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadMiniGame("MINIGAME-LEDY");
        }

        if (transform.position.y <= startPosition.y - 2f)
        {
            fall();
        }
    }

    public void LoadMiniGame(string name)
    {
        // Dezaktywacja innych obiektów w razie potrzeby...
        // £aduje minigrê w trybie additive (g³ówna scena pozostaje aktywna)
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void fall()
    {
        FindObjectOfType<PlayerHealth>().TakeDamage(1);
        gameObject.transform.position = new Vector3(startPosition.x, startPosition.y + 2f, startPosition.z);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime);
    }

    void RotateTowardsMovementDirection()
    {
        Quaternion newRotation = Quaternion.LookRotation(movementDirection);

        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, Time.deltaTime * 10f);
    }
}
