using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private int _amountAdditiosHelthPoint;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonShooterController>())
        {
            //other.gameObject.GetComponent<PlayerHealth>().AddingHealth(_amountAdditiosHelthPoint);
            playerHealth.AddingHealth(_amountAdditiosHelthPoint);
            Destroy(gameObject);
        }
    }
}
