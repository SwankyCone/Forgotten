using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float typingSpeed = 0.05f;
    public AudioSource typingSound;

    private Coroutine typingCoroutine;

    public void StartTyping(string message)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        // Wrap the message in [ ]
        string formattedMessage = $"[ {message} ]";
        typingCoroutine = StartCoroutine(TypeText(formattedMessage));
    }

    IEnumerator TypeText(string message)
    {
        textMesh.text = "";
        foreach (char letter in message.ToCharArray())
        {
            textMesh.text += letter;
            if (typingSound && !char.IsWhiteSpace(letter))
                typingSound.PlayOneShot(typingSound.clip);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
