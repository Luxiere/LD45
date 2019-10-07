using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cursors", menuName = "Game/Cursors")]
public class CustomCursor : ScriptableObject
{
    [System.Serializable]
    public struct CursorMapping
    {
        public CursorType type;
        public Texture2D texture;
        public Vector2 hotspot;
    }

    [SerializeField] CursorMapping[] cursorMappings = null;
    public void SetCursor(CursorType type)
    {
        CursorMapping mapping = GetCursorMapping(type);
        Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
    }

    public CursorMapping GetCursorMapping(CursorType type)
    {
        foreach (CursorMapping mapping in cursorMappings)
        {
            if (mapping.type == type) return mapping;
        }
        return cursorMappings[0];
    }
}
