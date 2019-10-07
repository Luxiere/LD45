using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAni : MonoBehaviour
{
    [SerializeField] Bird bird;
    public void NoPeck()
    {
        bird.NoPeck();
    }
}
