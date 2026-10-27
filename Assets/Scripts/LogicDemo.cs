using UnityEngine;
using UnityEngine.InputSystem;
public class LogicDemo : MonoBehaviour
{
    [SerializeField] private int hp = 50;
    [SerializeField] private int ammo = 3;
    [SerializeField] private int enemiesNear = 1;
    [SerializeField] private int coins= 4;
    [SerializeField] private bool isReloading;
    [SerializeField] private bool hasKey;
    // KOMENTARZ DO ZADANIA:
    // Komunikat „sprawdzam amunicję” pojawi się w konsoli dokładnie 1 raz.
    void Start()
    {
        
    }

    private void Report()
    {
        bool canShoot = (ammo > 0 && !isReloading);
        bool isDanger = (hp < 30 || enemiesNear > 3);
        bool canOpenDoor=(hasKey || coins >= 10);
        string status = (hp>0) ? "żyje" : "pokonany";
        Debug.Log($"Może strzelać: {canShoot} | W niebezpieczeństwie: {isDanger} | Otworzy drzwi: {canOpenDoor} | Status: {status}");
        isReloading = false;
        bool test1= isReloading && HasAmmo();
        bool test2 = isReloading & HasAmmo();
    }
    private bool HasAmmo()
    {
        Debug.Log("Sprawdzam amunicję...");
        return ammo > 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            Report();
        }

        
    }
}
