using UnityEngine;

public class RadioEnemy : MonoBehaviour
{
    [SerializeField] CounterTimerC4 counterC4;
    public void DestroyRadioByC4()
    {
        counterC4.SetTimerActive(true);
        Destroy(gameObject, 15f);
    }
}
