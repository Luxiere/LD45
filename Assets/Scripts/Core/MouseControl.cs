using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField] float XSensitivity = 2f;
    [SerializeField] CustomCursor customCursor = null;

    private bool m_cursorIsLocked = false;

    private Quaternion m_baseRot;
    private void Start()
    {
        m_baseRot = transform.localRotation;
    }

    private void Update()
    {
        if (TurnCamera()) return;
        if (InteractWithComponent()) return;
        customCursor.SetCursor(CursorType.Default);
    }

    private void LookRotation()
    {
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        m_baseRot *= Quaternion.Euler(0f, yRot, 0f);
        transform.localRotation = m_baseRot;
    }

    private bool TurnCamera()
    {
        if (Input.GetMouseButton(1))
        {
            m_cursorIsLocked = true;
            LookRotation();
        }
        else
        {
            m_cursorIsLocked = false;
        }
        UpdateCursorLock();
        return m_cursorIsLocked;
    }

    private void UpdateCursorLock()
    {
        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private bool InteractWithComponent()
    {
        RaycastHit[] hits = RaycastAllSorted();
        foreach (RaycastHit hit in hits)
        {
            IClickable[] clickables = hit.transform.GetComponents<IClickable>();
            foreach (IClickable clickable in clickables)
            {
                clickable.Click();
                if (customCursor != null) customCursor.SetCursor(clickable.GetCursorType());
                else Debug.LogError("No custom cursor");
                return true;
            }
        }
        return false;
    }

    private RaycastHit[] RaycastAllSorted()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        float[] distances = new float[hits.Length];
        for (int i = 0; i < hits.Length; i++)
        {
            distances[i] = hits[i].distance;
        }
        Array.Sort(distances, hits);
        return hits;
    }
    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
