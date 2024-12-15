using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject[] logs;

    [SerializeField] private UnityEvent OnIncreasedCollectedLogs;

    private int collectedLogs;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public int GetCollectedLogs()
    {
        return collectedLogs;
    }

    public int GetLogsQuantity()
    {
        return logs.Length;
    }

    public void IncreaseCollectedLogs()
    {
        collectedLogs++;
        OnIncreasedCollectedLogs.Invoke();
    }
}
