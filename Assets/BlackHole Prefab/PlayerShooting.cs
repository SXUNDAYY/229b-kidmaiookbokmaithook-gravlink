using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject blackHolePrefab;
    
    // ตัวแปรสำหรับเก็บอ้างอิงของหลุมดำที่ยิงออกไป
    private GameObject currentBlackHole;

    void Update()
    {
        // เงื่อนไข: คลิกเมาส์ซ้าย AND (currentBlackHole ต้องเป็นค่าว่าง หรือถูกทำลายไปแล้ว)
        if (Input.GetMouseButtonDown(0) && currentBlackHole == null)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // เมื่อ Instantiate แล้ว ให้เก็บตัว Object ที่สร้างไว้ในตัวแปร currentBlackHole
        currentBlackHole = Instantiate(blackHolePrefab, mousePos, Quaternion.identity);
        
        Debug.Log("ยิงหลุมดำแล้ว! ต้องรอให้ก้อนนี้หายไปก่อนถึงจะยิงใหม่ได้");
    }
}