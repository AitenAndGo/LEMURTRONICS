using UnityEngine;

public class movingSphere : MonoBehaviour
{
    public float torqueForce = 10f;    // Si�a momentu obrotowego (pr�dko�� turlania)
    public float maxDistance = 5f;     // Maksymalna odleg�o��, na jak� kula ma si� poruszy�
    public float maxAngularVelocity = 5f; // Maksymalna pr�dko�� obrotowa kuli
    public float brakeForce = 2f;      // Dodatkowa si�a hamowania przy nawrocie

    private Rigidbody rb;
    private Vector3 startPosition;     // Pozycja startowa kuli
    private bool movingForward = true; // Flaga, czy kula turla si� do przodu

    void Start()
    {
        // Pobierz komponent Rigidbody
        rb = GetComponent<Rigidbody>();

        // Zapisz pozycj� startow� kuli
        startPosition = transform.position;

        // Upewnij si�, �e obiekt ma Rigidbody
        if (rb == null)
        {
            Debug.LogError("Brak komponentu Rigidbody na obiekcie!");
        }

        // Ustaw maksymaln� pr�dko�� obrotow�
        rb.maxAngularVelocity = maxAngularVelocity;
    }

    void Update()
    {
        // Oblicz przemieszczenie wzd�u� osi X od pozycji startowej
        float displacement = transform.position.z - startPosition.z;

        // Je�li kula osi�gnie maksymaln� odleg�o�� do przodu, zmie� kierunek na wsteczny
        if (displacement >= maxDistance && movingForward)
        {
            movingForward = false;  // Zmie� kierunek na wsteczny
            ApplyBrake();           // Zastosuj dodatkowe hamowanie
        }
        // Je�li kula wr�ci do pozycji startowej lub nieznacznie przed ni�, zmie� kierunek na prz�d
        else if (displacement <= 0f && !movingForward)
        {
            movingForward = true;   // Zmie� kierunek na prz�d
            ApplyBrake();           // Zastosuj dodatkowe hamowanie
        }

        // Ustaw moment obrotowy, aby kula turla�a si� w odpowiednim kierunku
        float direction = movingForward ? 1f : -1f;

        // Dodaj moment obrotowy do turlania kuli, kontroluj�c jej pr�dko��
        rb.AddTorque(transform.right * direction * torqueForce);
    }

    // Zastosuj si�� hamowania, aby kula szybciej zmienia�a kierunek
    void ApplyBrake()
    {
        // Zastosuj odwrotny moment obrotowy, aby kula wyhamowa�a
        rb.angularVelocity *= (1f / brakeForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            FindObjectOfType<PlayerController>().fall();
        }
    }
}
