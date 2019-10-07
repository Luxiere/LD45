using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeActive : MonoBehaviour
{
    Inactive[] inactives;
    public void FindInactives(string name)
    {
        inactives = (Inactive[]) Resources.FindObjectsOfTypeAll(typeof(Inactive));
        foreach (Inactive inactive in inactives)
        {
            if (inactive.name == name)
            {
                inactive.gameObject.SetActive(true);
            }
        }
    }
} 