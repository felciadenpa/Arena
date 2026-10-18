using UnityEngine;
//1. Awake 0-> OnEnable 0->Start 1->Update 1
//2. Przy wyłączeniu komponentu: OnDisable Przy włączeniu obiektu: OnEnable. Tylko raz na cały czas życia skryptu Awake i Start
//3. Tylko Awake sie wykonalo
//4.Awake zawsze jako pierwsze- uzyje do przygotowania obiektu np danych poczatkowych, Start uzyje kiedy moj skrypt musi sie odwolac do innych obiektow na scenie 

public class LifecycleLogger : MonoBehaviour
{
    private bool firstFrameLogged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Debug.Log($"[{ Time.frameCount}] Awake");
    }
    private void OnEnable()
    {
        Debug.Log($"[{ Time.frameCount}] OnEnable");
    }
    private void Start()
    {
        Debug.Log($"[{ Time.frameCount}] Start");
    }

    private void OnDisable()
    {
        Debug.Log($"[{ Time.frameCount}] OnDisable");
    }
    private void OnDestroy()
    {
        Debug.Log($"[{ Time.frameCount}] OnDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstFrameLogged)
        {
            Debug.Log($"[{Time.frameCount}] Update (pierwsza klatka)");
            firstFrameLogged = true;
        }
    }
}
