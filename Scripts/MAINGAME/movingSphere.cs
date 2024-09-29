using UnityEngine;

public class movingSphere : MonoBehaviour
{
    public float torqueForce = 10f;    // Si³a momentu obrotowego (prêdkoœæ turlania)
    public float maxDistance = 5f;     // Maksymalna odleg³oœæ, na jak¹ kula ma siê poruszyæ
    public float maxAngularVelocity = 5f; // Maksymalna prêdkoœæ obrotowa kuli
    public float brakeForce = 2f;      // Dodatkowa si³a hamowania przy nawrocie

    private Rigidbody rb;
    private Vector3 startPosition;     // Pozycja startowa kuli
    private bool movingForward = true; // Flaga, czy kula turla siê do przodu

    void Start()
    {
        // Pobierz komponent Rigidbody
        rb = GetComponent<Rigidbody>();

        // Zapisz pozycjê startow¹ kuli
        startPosition = transform.position;

        // Upewnij siê, ¿e obiekt ma Rigidbody
        if (rb == null)
        {
            Debug.LogError("Brak komponentu Rigidbody na obiekcie!");
        }

        // Ustaw maksymaln¹ prêdkoœæ obrotow¹
        rb.maxAngularVelocity = maxAngularVelocity;
    }

    void Update()
    {
        // Oblicz przemieszczenie wzd³u¿ osi X od pozycji startowej
        float displacement = transform.position.z - startPosition.z;

        // Jeœli kula osi¹gnie maksymaln¹ odleg³oœæ do przodu, zmieñ kierunek na wsteczny
        if (displacement >= maxDistance && movingForward)
        {
            movingForward = false;  // Zmieñ kierunek na wsteczny
            ApplyBrake();           // Zastosuj dodatkowe hamowanie
        }
        // Jeœli kula wróci do pozycji startowej lub nieznacznie przed ni¹, zmieñ kierunek na przód
        else if (displacement <= 0f && !movingForward)
        {
            movingForward = true;   // Zmieñ kierunek na przód
            ApplyBrake();           // Zastosuj dodatkowe hamowanie
        }

        // Ustaw moment obrotowy, aby kula turla³a siê w odpowiednim kierunku
        float direction = movingForward ? 1f : -1f;

        // Dodaj moment obrotowy do turlania kuli, kontroluj¹c jej prêdkoœæ
        rb.AddTorque(transform.right * direction * torqueForce);
    }

    // Zastosuj si³ê hamowania, aby kula szybciej zmienia³a kierunek
    void ApplyBrake()
    {
        // Zastosuj odwrotny moment obrotowy, aby kula wyhamowa³a
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
