using UnityEngine;
using TMPro;

public class Log : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI popUpText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void Interact()
    {
        gameManager.IncreaseCollectedLogs();
        Destroy(gameObject);
    }
}
