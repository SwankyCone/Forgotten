using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dial : MonoBehaviour
{
    [Header(" settings ")]
    [SerializeField] private float animationDuration;
    private bool isRotating = false;
    private int currentIndex;

    [Header(" Events ")]
    [SerializeField] private UnityEvent<Dial> onDialRotated;

    private void Start()
    {
        currentIndex = Random.Range(0, 10);
        transform.localRotation = Quaternion.Euler(currentIndex * -36, 0, 0);
    }

    public void Rotate()
    {
        if (isRotating)
            return;

        isRotating = true;

        currentIndex++;

        if (currentIndex >= 10) 
            currentIndex = 0;
    }

}
