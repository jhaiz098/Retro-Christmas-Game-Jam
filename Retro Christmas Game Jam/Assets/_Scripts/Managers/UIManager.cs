using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedLogsText;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
        UpdateCollectedLogsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCollectedLogsText()
    {
        collectedLogsText.text = gameManager.GetCollectedLogs() + " / " + gameManager.GetLogsQuantity();
    }
}
