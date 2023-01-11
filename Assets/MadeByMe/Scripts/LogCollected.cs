using UnityEngine;
using UnityEngine.Events;
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
    private Image enginLog;
    private bool engineLogUnlocked;

    [SerializeField]
    private Image medLog;
    private bool medLogUnlocked;

    [SerializeField]
    private Image finalLog;
    private bool finalLogUnlocked;

    public UnityEvent finalLogAvailable;

    // Start is called before the first frame update
    void Start()
    {
        finalLogAvailable = new UnityEvent();
    }

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
            case "EnginLog":
                EnginLogUnlock();
                break;
            case "MedLog":
                MedLogUnlock();
                break;
            case "finalLog":
                FinalLogUnlock();
                break;
        }
    }

    private void ShieldLogUnlock()
    {
        shieldLogUnlocked = true;
        shieldLog.color = Color.white;
        CheckIfFinalAvailable();
    }

    private void EnginLogUnlock()
    {
        engineLogUnlocked = true;
        enginLog.color = Color.white;
        CheckIfFinalAvailable();
    }

    private void CrewLogUnlock()
    {
        crewLogUnlocked = true;
        crewLog.color = Color.white;
        CheckIfFinalAvailable();
    }

    private void MedLogUnlock()
    {
        medLogUnlocked = true;
        medLog.color = Color.white;
        CheckIfFinalAvailable();
    }

    void CheckIfFinalAvailable()
    {
        if (shieldLogUnlocked && engineLogUnlocked && crewLogUnlocked && medLogUnlocked)
        {
            finalLogAvailable.Invoke();
        }
    }

    private void FinalLogUnlock()
    {
        finalLogUnlocked = true;
        finalLog.color = Color.white;
    }
}
