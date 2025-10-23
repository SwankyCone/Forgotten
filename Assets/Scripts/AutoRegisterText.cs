using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AutoRegisterText : MonoBehaviour
{
    private TextMeshProUGUI textElement;

    void Awake()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        if (FontManager.Instance != null)
            FontManager.Instance.RegisterText(textElement);
    }

    void OnDestroy()
    {
        if (FontManager.Instance != null)
            FontManager.Instance.UnregisterText(textElement);
    }
}
