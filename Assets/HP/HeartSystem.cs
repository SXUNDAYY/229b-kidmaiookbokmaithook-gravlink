using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [Header("Heart Sprites Settings")]
    public SpriteRenderer[] heartSprites; 
    
    [Header("Visual Settings")]
    [Range(0, 1)] public float deadAlpha = 0.2f; // ความโปร่งใสตอนตาย (0.2 คือจางมาก)
    public Color damageFlashColor = Color.red; // สีตอนกระพริบเมื่อโดนดาเมจ

    private int currentHP;

    void Start()
    {
        currentHP = heartSprites.Length;
        // ตั้งค่าให้ทุกดวงสว่างเต็มที่ตอนเริ่ม
        ResetHearts();
    }

    [ContextMenu("Decrease HP")]
    public void DecreaseHP()
    {
        if (currentHP > 0)
        {
            currentHP--;
            
            // ปรับสีดวงที่เสียไปให้จางลง (Alpha น้อยลง)
            Color c = heartSprites[currentHP].color;
            c.a = deadAlpha; 
            heartSprites[currentHP].color = c;

            Debug.Log("HP ลด! เหลือ: " + currentHP);
        }
    }

    [ContextMenu("Increase HP")]
    public void IncreaseHP()
    {
        if (currentHP < heartSprites.Length)
        {
            // ปรับสีดวงที่ได้คืนมาให้สว่างเต็มที่
            Color c = heartSprites[currentHP].color;
            c.a = 1f; 
            heartSprites[currentHP].color = c;
            
            currentHP++;
        }
    }

    private void ResetHearts()
    {
        foreach(SpriteRenderer sr in heartSprites) {
            if (sr != null) {
                Color c = sr.color;
                c.a = 1f;
                sr.color = c;
            }
        }
    }
}