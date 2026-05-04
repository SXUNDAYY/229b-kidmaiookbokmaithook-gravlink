using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    [Header("UI Display")]
    public Image targetIcon;           // รูปอุกกาบาตเป้าหมายจอกลาง
    public TextMeshProUGUI countText;  // ตัวเลขภารกิจ (Mission_Count_Text)
    public WaveBarController waveBar;  // สคริปต์ควบคุมหลอด Wave

    [Header("Meteor Data")]
    public Sprite[] meteorSprites;     // รูปอุกกาบาตแมวทั้ง 3 แบบ

    private int currentWave = 1;
    private int remainingTargets;
    private int totalTargetsInWave;
    private Sprite currentTargetSprite;

    void Start()
    {
        // เริ่มต้น Wave แรกทันทีที่รันเกม
        StartNewWave();
    }

    public void StartNewWave()
    {
        // ถ้าจบ Wave 3 แล้วให้หยุดทำงาน
        if (currentWave > 3)
        {
            Debug.Log("Mission Complete! ยาน GRAVLINK ปลอดภัยแล้วกัปตัน!");
            return;
        }

        // 1. สุ่มรูปอุกกาบาตเป้าหมายจาก Array ที่เราใส่ไว้ (3 แบบ)
        int randomIndex = Random.Range(0, meteorSprites.Length);
        currentTargetSprite = meteorSprites[randomIndex];
        targetIcon.sprite = currentTargetSprite;

        // 2. สุ่มจำนวนเป้าหมายตามช่วงที่กำหนดของแต่ละ Wave
        if (currentWave == 1) remainingTargets = Random.Range(10, 26);      // Wave 1: 10-25 ลูก
        else if (currentWave == 2) remainingTargets = Random.Range(15, 26); // Wave 2: 15-25 ลูก
        else if (currentWave == 3) remainingTargets = Random.Range(20, 31); // Wave 3: 20-30 ลูก

        totalTargetsInWave = remainingTargets;
        UpdateMissionUI();
    }

    // ฟังก์ชันสำหรับให้ Meteor.cs เรียกเมื่อถูกคลิก
    public void OnMeteorDestroyed(Sprite destroyedSprite)
    {
        // เช็คว่ารูปอุกกาบาตที่โดนยิง ตรงกับรูปเป้าหมายที่จอกลางไหม
        if (destroyedSprite == currentTargetSprite)
        {
            remainingTargets--;
            UpdateMissionUI();

            // เมื่อทำลายครบจำนวน ให้ขึ้น Wave ใหม่
            if (remainingTargets <= 0)
            {
                currentWave++;
                StartNewWave();
            }
        }
    }

    void UpdateMissionUI()
    {
        // อัปเดตตัวเลข "x จำนวน" บนหน้าจอ
        countText.text = "x " + remainingTargets.ToString();

        // คำนวณความคืบหน้าสะสมทั้งเกม (แบ่งสีละ 33%)
        // สูตร: (จำนวน Wave ที่ผ่านมาแล้ว * 0.33) + (ความคืบหน้าใน Wave ปัจจุบัน * 0.33)
        float waveProgress = 1f - ((float)remainingTargets / totalTargetsInWave);
        float totalProgress = ((currentWave - 1) * 0.333f) + (waveProgress * 0.333f);

        // ส่งค่าไปที่ WaveBar เพื่อปรับขนาดและเปลี่ยนสี (เขียว -> เหลือง -> แดง)
        if (waveBar != null)
        {
            waveBar.UpdateTotalProgress(totalProgress);
        }
    }

    // ฟังก์ชันสำหรับให้ MeteorSpawner มาดึงเลข Wave ไปใช้ปรับความยาก
    public int GetCurrentWave()
    {
        return currentWave;
    }
}