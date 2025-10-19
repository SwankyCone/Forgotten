using UnityEngine;
using TMPro;
using System.Collections;

public class OutsideDinerDialogue : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI instructionText; // shows "[Press SPACE to continue]"
    public GameObject dialogueBackground;

    [Header("Dialogue Settings")]
    public string[] dialogueLines;
    public float textSpeed = 0.05f;

    private int index;

    void Start()
    {
        instructionText.text = "[Press SPACE to continue]";
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueText.text == dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
                instructionText.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";
        instructionText.gameObject.SetActive(false);

        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        instructionText.gameObject.SetActive(true);
    }

    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            StartCoroutine(CloseDialogue());
        }
    }

    IEnumerator CloseDialogue()
    {
        yield return new WaitForSeconds(0.3f);
        dialogueText.text = "";
        instructionText.text = "";
        dialogueBackground.SetActive(false); // hides the background too
        gameObject.SetActive(false);
    }
}
