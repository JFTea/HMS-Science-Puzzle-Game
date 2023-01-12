using UnityEngine;
using UnityEngine.UI;

public class LogCollected : MonoBehaviour
{
    [SerializeField]
    private Image shieldLog;
    private bool shieldLogUnlocked;

    [SerializeField]
    private Image crewLog;
    private bool crewLogUnlocked;

    [SerializeField]
    private Image engineLog;
    private bool engineLogUnlocked;

    [SerializeField]
    private Image medLog;
    private bool medLogUnlocked;

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
        shieldLogUnlocked = true;
        shieldLog.color = Color.white;
        shieldLog.GetComponent<Button>().enabled = true;
    }

    private void EnginLogUnlock()
    {
        engineLogUnlocked = true;
        engineLog.color = Color.white;
        engineLog.GetComponent<Button>().enabled = true;
    }

    private void CrewLogUnlock()
    {
        crewLogUnlocked = true;
        crewLog.color = Color.white;
        crewLog.GetComponent<Button>().enabled = true;
    }

    private void MedLogUnlock()
    {
        medLogUnlocked = true;
        medLog.color = Color.white;
        medLog.GetComponent<Button>().enabled = true;
    }
}
