using UnityEngine;
using UnityEngine.InputSystem;
public class DamageCalculator : MonoBehaviour
{
    [SerializeField] private int baseDamage = 10;
    [SerializeField] private float weaponMultiplier = 1.5f;
    [SerializeField][Range(0f, 1f)] private float critChance = 0.2f;
    private const int ComboBonus = 5;
    private int hitCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            hitCount++;
            float damage = baseDamage * weaponMultiplier;
            bool isCrit = Random.value < critChance;
            if(isCrit)
            {
                damage *= 2; 
            }
            if(hitCount% 3 == 0)
            {
                damage += ComboBonus;
            }
            int finalDamage = Mathf.RoundToInt(damage);
            string critText = isCrit ? " (Critical Hit!)" : "";
            Debug.Log($"Uderzenie {hitCount}: Zadajesz {finalDamage} obrażeń. {critText}");
        }

    }
}
