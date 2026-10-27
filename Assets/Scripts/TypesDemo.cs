using UnityEngine;

public class TypesDemo : MonoBehaviour

{
    private const int MaxLives = 5;
    private readonly System.DateTime createdAt = System.DateTime.Now;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"7/2={7/2}");
        Debug.Log($"7/2f={7 / 2f}");    
        Debug.Log($"7%3={7 % 3}");
        Debug.Log($"-7/2={-7 / 2}");    
        Debug.Log($"-7%3={-7 % 3}");
        Debug.Log($"10/4*4={10 / 4 * 4}");
        Debug.Log($"10 / 4f * 4={10 / 4f * 4}");
        Debug.Log($"(float)(7 / 2)={(float)(7 / 2)}");
        Debug.Log($"(int)3.9f={(int)3.9f}");
        Debug.Log($"(int)-3.9f={(int)-3.9f}");
        Debug.Log($"Mathf.FloorToInt(-3.9f)={Mathf.FloorToInt(-3.9f)}");
        Debug.Log($"Mathf.RoundToInt(2.5f)\r\n={Mathf.RoundToInt(2.5f)}");
        Debug.Log($"Mathf.RoundToInt(3.5f)\r\n={Mathf.RoundToInt(3.5f)}");
        ShowTypes();


    }

    private void ShowTypes()
    {
        int playerLives = 3;
        float playerSpeed = 5.5f;
        string playerName = "Bohater";
        bool isAlive = true;
        char actionKey = 'E';
        long globalScore = 10000000000L;
        decimal itemPrice = 15.99m;
        Vector3 coinPosition = new Vector3(1.0f, 2.0f, 0.5f);
        Color coinColorMaterial = new Color(1.0f, 0.84f, 0.0f); // złoty kolor

        Debug.Log($"Statystyki gracza {playerName}: Życia: {playerLives}, Prędkość: {playerSpeed}, Żywy: {isAlive}. Klawisz akcji: {actionKey}. Pozycja monety: {coinPosition}, Cena w sklepie: {itemPrice} zł, Wynik globalny: {globalScore} pkt.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
