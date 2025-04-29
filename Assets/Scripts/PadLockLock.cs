using UnityEngine;

public class PadlockLock : MonoBehaviour
{
    public Transform[] dials;          // Assign 4 dials in the Inspector
    public int[] correctCode = { 3, 5, 7, 2 }; // The correct code (example with 4 digits)
    private int[] currentCode;

    private int selectedDial = 0;
    private bool isUnlocked = false;

    void Start()
    {
        currentCode = new int[dials.Length];

        // Ensure that all dials start at 0 (displaying the number 0)
        for (int i = 0; i < dials.Length; i++)
        {
            currentCode[i] = 0;
            RotateDial(i); // Set initial rotation for each dial
        }
    }

    void Update()
    {
        if (isUnlocked) return;

        HandleInput();
        CheckCode();
    }

    void HandleInput()
    {
        // Move between dials
        if (Input.GetKeyDown(KeyCode.A)) selectedDial = Mathf.Max(0, selectedDial - 1);
        if (Input.GetKeyDown(KeyCode.D)) selectedDial = Mathf.Min(dials.Length - 1, selectedDial + 1);

        // Rotate selected dial
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentCode[selectedDial] = (currentCode[selectedDial] + 1) % 10; // Wrap around 0-9
            RotateDial(selectedDial);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            currentCode[selectedDial] = (currentCode[selectedDial] - 1 + 10) % 10; // Wrap around 9-0
            RotateDial(selectedDial);
        }
    }

    void RotateDial(int dialIndex)
    {
        // Rotate dial based on the number (36 degrees per digit, 360/10)
        float angle = currentCode[dialIndex] * 36f;
        dials[dialIndex].localRotation = Quaternion.Euler(angle, 0, 0);
    }

    void CheckCode()
    {
        // Check if the current code matches the correct code
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i])
                return;
        }

        Unlock();
    }

    void Unlock()
    {
        isUnlocked = true;
        Debug.Log("Padlock Unlocked!");

        // Optional: Add animation, sound, or event trigger here
        Destroy(gameObject, 1f); // Destroy padlock after 1 second
    }
}