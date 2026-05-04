using UnityEngine;

public class MyCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // ช่องสำหรับใส่รูป
    public Vector2 hotSpot = new Vector2(16, 16); // จุดคลิกกลางภาพ

    void Start()
    {
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
    }
}