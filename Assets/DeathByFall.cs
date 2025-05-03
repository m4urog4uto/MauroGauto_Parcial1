using UnityEngine;

public class DeathByFall : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            playerBase.RemoveLive();
        }
    }
}
