using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class FontManager : MonoBehaviour
{
    public static FontManager Instance;

    [Header("Font Assets")]
    public TMP_FontAsset regularFont;
    public TMP_FontAsset dyslexicFont;

    private bool useDyslexicFont = false;
    private List<TextMeshProUGUI> registeredTexts = new List<TextMeshProUGUI>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Load saved preference
            useDyslexicFont = PlayerPrefs.GetInt("UseDyslexicFont", 0) == 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterText(TextMeshProUGUI text)
    {
        if (!registeredTexts.Contains(text))
            registeredTexts.Add(text);

        ApplyFontToText(text);
    }

    public void UnregisterText(TextMeshProUGUI text)
    {
        registeredTexts.Remove(text);
    }

    public void ToggleFont(bool dyslexic)
    {
        useDyslexicFont = dyslexic;
        PlayerPrefs.SetInt("UseDyslexicFont", dyslexic ? 1 : 0);

        foreach (var text in registeredTexts)
        {
            ApplyFontToText(text);
        }
    }

    private void ApplyFontToText(TextMeshProUGUI text)
    {
        text.font = useDyslexicFont ? dyslexicFont : regularFont;
    }

    public bool IsUsingDyslexicFont()
    {
        return useDyslexicFont;
    }

    public void ToggleFontWithButton()
    {
        ToggleFont(!useDyslexicFont);
    }

}
