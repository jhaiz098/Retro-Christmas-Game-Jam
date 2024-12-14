using UnityEngine;

public class BonFire : MonoBehaviour
{
    [SerializeField] private float playerDetectionRange;
    [SerializeField] private LayerMask playerMask;
    private bool burning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D playerDetector = Physics2D.OverlapCircle(transform.position, playerDetectionRange, playerMask);

        if (playerDetector != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SetFire();
            }
        }
    }

    public void SetFire()
    {
        burning = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, playerDetectionRange);
    }
}
