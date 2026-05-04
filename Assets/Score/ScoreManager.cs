using UnityEngine;
using TMPro; // จำเป็นสำหรับการควบคุม TextMeshPro

public class ScoreManager : MonoBehaviour
{
    [Header("UI Reference")]
    // ลากวัตถุที่เป็นตัวเลข (Point Text) มาใส่ที่นี่
    public TextMeshProUGUI pointText; 

    private int currentScore = 0;

    void Start()
    {
        // เริ่มต้นเกมให้แสดงเลข 0
        UpdateScoreUI();
    }

    // ฟังก์ชันหลักสำหรับเพิ่มคะแนน
    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    // ฟังก์ชันอัปเดตตัวเลขบนหน้าจอ
    void UpdateScoreUI()
    {
        if (pointText != null)
        {
            pointText.text = currentScore.ToString();
        }
    }

    // --- ส่วนสำหรับกด TEST ใน Inspector ---

    [ContextMenu("Test: Add 10 Points")]
    public void TestAdd10()
    {
        AddScore(10);
        Debug.Log("ทดสอบเพิ่มคะแนน: +10 | คะแนนปัจจุบัน: " + currentScore);
    }

    [ContextMenu("Test: Add 100 Points")]
    public void TestAdd100()
    {
        AddScore(100);
        Debug.Log("ทดสอบเพิ่มคะแนน: +100 | คะแนนปัจจุบัน: " + currentScore);
    }

    [ContextMenu("Reset Score")]
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}