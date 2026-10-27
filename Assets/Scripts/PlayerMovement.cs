using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Ruch i Arena")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector2 arenaHalfSize = new Vector2(8.5f, 4.5f);

    // KROK 1: Stała i pola dotyczące sprintu w Inspectorze
    [Header("Sprint")]
    [SerializeField] private float sprintMultiplier = 1.8f;
    [SerializeField] private float staminaDrain = 30f;
    [SerializeField] private float staminaRegen = 15f;
    [SerializeField] private float recoverThreshold = 25f;
    private const float MaxStamina = 100f;

    // KROK 2: Pola podglądu (stamina zaczyna od MaxStamina)
    [Header("Podgląd")]
    [SerializeField] private float stamina = MaxStamina;
    [SerializeField] private bool exhausted;
    [SerializeField] private float measuredSpeed;
    private InputAction moveAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move"); 
    }

    // Próba wpisania 'transform.position.x = 0f;' wyrzuca błąd "Cannot modify the return value...".
    // Dzieje się tak, ponieważ 'transform.position' zwraca Vector3, który w C# jest 
    // strukturą (struct), czyli typem wartościowym. Kiedy się do niego odwołujemy, 
    // dostajemy jedynie tymczasową kopię obecnej pozycji. Zmiana 'x' zmodyfikowałaby 
    // tylko tę ulotną kopię, a nie faktyczny obiekt, więc kompilator nam tego zabrania.
    // Aby zmienić pozycję w Unity, musimy nadpisać cały wektor nowym, np.:
    // transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    void Update()
    {
        // --- CZĘŚĆ 1: ODCZYT WEJŚCIA I RUCH ---
        Vector2 input = moveAction.ReadValue<Vector2>();

        // KROK 3: Ustalenie wartości logicznych do sprintu
        // Czy wciskamy i przytrzymujemy lewy Shift
        bool shiftHeld = Keyboard.current.leftShiftKey.isPressed;

        // Czy gracz naciska jakikolwiek kierunek
        bool isMoving = input.sqrMagnitude > 0f;

        // Czy gracz biegnie: Shift + ruch + brak wyczerpania
        bool sprinting = shiftHeld && isMoving && !exhausted;

        // KROK 4: Obliczenie obecnej prędkości na podstawie tego, czy gracz sprintuje
        float currentSpeed = sprinting ? (speed * sprintMultiplier) : speed;
        measuredSpeed = currentSpeed; // Aktualizujemy podgląd w Inspectorze

        // Obliczanie kierunku ruchu i przesuwanie gracza
        Vector3 dir = new Vector3(input.x, 0f, input.y);
        transform.position += dir * currentSpeed * Time.deltaTime;

        // Ograniczanie pozycji gracza (ściany areny z poprzedniego zadania)
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -arenaHalfSize.x, arenaHalfSize.x);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -arenaHalfSize.y, arenaHalfSize.y);
        transform.position = clampedPosition;

        // --- CZĘŚĆ 2: ZARZĄDZANIE WYTRZYMAŁOŚCIĄ (STAMINĄ) ---

        // KROK 5: Zmiana wytrzymałości zależnie od tego, czy gracz biegnie
        if (sprinting)
        {
            // Tracimy staminę w czasie (odjęcie)
            stamina -= staminaDrain * Time.deltaTime;
        }
        else
        {
            // Odzyskujemy staminę w czasie (dodawanie)
            stamina += staminaRegen * Time.deltaTime;
        }

        // Pilnujemy, aby stamina nie spadła poniżej zera ani nie przekroczyła maksimum
        stamina = Mathf.Clamp(stamina, 0f, MaxStamina);

        // KROK 6: Obsługa wyczerpania
        if (stamina <= 0f)
        {
            // Gracz biegał tak długo, aż całkowicie opadł z sił
            exhausted = true;
        }

        // Jeśli gracz jest wyczerpany, odzyskuje możliwość biegu DOPIERO po przekroczeniu progu
        if (exhausted && stamina >= recoverThreshold)
        {
            exhausted = false;
        }
    }
}

