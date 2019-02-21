using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackControlsUI : MonoBehaviour
{
    public static HackControlsUI instance;

    List<Text> listOfControlsText;

    [SerializeField]
    Text prefabControlText;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        instance = this;
        canvasGroup = GetComponent<CanvasGroup>();

        ClearControls();

        listOfControlsText = new List<Text>();
    }

    public void AddControlsText(string controlInfo)
    {
        Text text = Instantiate(prefabControlText, transform);
        text.text = controlInfo;
        listOfControlsText.Add(text);
    }

    public void DisplayControls()
    {
        canvasGroup.alpha = 1f;
    }

    public void ClearControls()
    {
        canvasGroup.alpha = 0f;
        foreach(Text item in GetComponentsInChildren<Text>())
        {
            Destroy(item.gameObject);
        }
    }

}
