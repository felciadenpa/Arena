using UnityEngine;

public class HelloArena : MonoBehaviour
{
    [SerializeField] private string playerName = "Gracz";
    [SerializeField] private int lives =3;
    [SerializeField] private float speed = 5.5f;
    [SerializeField] private bool easyMode = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Hello {playerName}!");
        Debug.Log($"Lives: {lives}");
        Debug.Log($"Speed: {speed}");
        Debug.Log($"Easy Mode: {easyMode}");

    }


}
