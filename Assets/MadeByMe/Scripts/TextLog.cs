using System.IO;
using TMPro;
using UnityEngine;

public class TextLog : MonoBehaviour
{
    private TMP_Text displayText;

    [SerializeField]
    private Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        displayText = GetComponent<TMP_Text>();
    }

    public void ImportTextLog(string logName)
    {
        displayText.text = File.ReadAllText(Application.dataPath + "/MadeByMe/Data/TextLogs/" + logName + ".txt");
        canvas.enabled = true;
    }
}
