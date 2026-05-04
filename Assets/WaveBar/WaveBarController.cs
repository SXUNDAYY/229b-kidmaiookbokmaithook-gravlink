using UnityEngine;

public class WaveBarController : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer fillRenderer; // ลาก Wave_Fill มาใส่ที่นี่

    [Header("Color Settings")]
    public Color color1 = Color.green;
    public Color color2 = Color.yellow;
    public Color color3 = Color.red;

    private float maxScaleX; 

    void Awake()
    {
        // บันทึกความยาวสูงสุดจากที่คุณกะไว้ในหน้า Scene
        if (fillRenderer != null)
        {
            maxScaleX = fillRenderer.transform.localScale.x;
            // เริ่มต้นที่ 0 (ซ่อนแถบไว้ข้างหลังขอบซ้าย)
            UpdateTotalProgress(0f); 
        }
    }

    public void UpdateTotalProgress(float totalProgress)
    {
        if (fillRenderer == null) return;

        // 1. ปรับขนาดแกน X ตาม Progress (0 ถึง 1)
        float currentScaleX = Mathf.Lerp(0, maxScaleX, totalProgress);
        fillRenderer.transform.localScale = new Vector3(currentScaleX, fillRenderer.transform.localScale.y, fillRenderer.transform.localScale.z);

        // 2. เปลี่ยนสีตามช่วง 33%
        if (totalProgress <= 0.333f)
        {
            fillRenderer.color = color1;
        }
        else if (totalProgress <= 0.666f)
        {
            fillRenderer.color = color2;
        }
        else
        {
            fillRenderer.color = color3;
        }
    }

    // --- ปุ่มสำหรับคลิกขวาเทสใน Inspector ---
    [ContextMenu("Test: 33% (Wave 1 Green)")]
    public void Test33() => UpdateTotalProgress(0.333f);

    [ContextMenu("Test: 66% (Wave 2 Yellow)")]
    public void Test66() => UpdateTotalProgress(0.666f);

    [ContextMenu("Test: 100% (Wave 3 Red)")]
    public void Test100() => UpdateTotalProgress(1f);
}