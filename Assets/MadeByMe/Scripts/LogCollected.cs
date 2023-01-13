using UnityEngine;
using UnityEngine.UI;

public class LogCollected : MonoBehaviour
{
    [SerializeField]
    private Image shieldLog;

    [SerializeField]
    private Image crewLog;

    [SerializeField]
    private Image engineLog;

    [SerializeField]
    private Image medLog;

    public void CollectedLog(string logName)
    {
        switch (logName)
        {
            case "ShieldLog":
                ShieldLogUnlock();
                break;
            case "CrewLog":
                CrewLogUnlock();
                break;
            case "EngineLog":
                EnginLogUnlock();
                break;
            case "MedLog":
                MedLogUnlock();
                break;
        }
    }

    private void ShieldLogUnlock()
    {
        shieldLog.GetComponent<Button>().enabled = true;
    }

    private void EnginLogUnlock()
    {
        engineLog.GetComponent<Button>().enabled = true;
    }

    private void CrewLogUnlock()
    {
        crewLog.GetComponent<Button>().enabled = true;
    }

    private void MedLogUnlock()
    {
        medLog.GetComponent<Button>().enabled = true;
    }
}
