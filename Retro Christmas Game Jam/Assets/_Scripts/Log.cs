using UnityEngine;
using TMPro;

public class Log : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI popUpText;

    public void Interact()
    {
        Debug.Log("Interacting with log");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            popUpText.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            popUpText.gameObject.SetActive(false);
        }
    }
}
