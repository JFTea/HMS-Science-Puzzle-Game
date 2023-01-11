using System.IO;
using TMPro;
using UnityEngine;

public class TextLog : MonoBehaviour
{
    private TMP_Text displayText;
    // Start is called before the first frame update
    void Awake()
    {
        displayText = GetComponent<TMP_Text>();
    }

    public void ImportTextLog(string logName)
    {
        displayText.text = File.ReadAllText(Application.dataPath + "/MadeByMe/TextLogs/" + logName + ".txt");
        GetComponentInParent<Canvas>().enabled = true;
    }
}
