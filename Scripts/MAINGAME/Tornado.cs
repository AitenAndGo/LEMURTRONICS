using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float rotationSpeed = 200f;

    public Vector3 pointA;
    public Vector3 pointB;

    public float moveSpeed = 5f;

    private Vector3 currentTarget;

    void Start()
    {
        randomTornado();
        transform.position = pointA;
        currentTarget = pointB;
    }

    public void randomTornado()
    {
        pointA.y = 1.81f;
        pointB.y = 1.81f;

        pointA.x = -20f;
        pointB.x = 20f;

        pointA.z = Random.Range(10f, 0f);
        pointB.z = Random.Range(15f, 0f);
    }

    void Update()
    {
        RotateTornado();

        MoveTornado();
    }

    void RotateTornado()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void MoveTornado()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            if (currentTarget == pointB)
            {
                randomTornado();
                currentTarget = pointA;
            }
            else
            {
                randomTornado();
                currentTarget = pointB;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            FindObjectOfType<PlayerController>().fall();
        }
    }
}

