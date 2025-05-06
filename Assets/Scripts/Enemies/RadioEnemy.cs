using UnityEngine;

public class RadioEnemy : MonoBehaviour
{
    [SerializeField] CounterTimerC4 counterC4;
    // [SerializeField] RadioExplosionSound radioExplosion;
    GameObject radioExplosion;
    RadioExplosionSound radioExplosionSound;
    public void DestroyRadioByC4()
    {
        counterC4.SetTimerActive(true);
        Destroy(gameObject, 15f);
    }

    void Start()
    {
        GameObject radioExplosion = new GameObject("RadioExplosionSound");
        transform.SetParent(radioExplosion.transform);
        radioExplosionSound = radioExplosion.AddComponent<RadioExplosionSound>();
    }

    void OnDestroy()
    {
        if (radioExplosionSound != null)
        {
            radioExplosionSound.PlaySound();
        }
    }
}
