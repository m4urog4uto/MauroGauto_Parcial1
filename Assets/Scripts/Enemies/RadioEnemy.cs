using System.Collections.Generic;
using UnityEngine;

public class RadioEnemy : MonoBehaviour
{
    [SerializeField] CounterTimerC4 counterC4;
    RadioExplosionSound radioExplosionSound;

    [SerializeField] private List<GameObject> enemiesDefenders = new List<GameObject>();

    [SerializeField] Transform enemiesSpawn;

    public void DestroyRadioByC4()
    {
        counterC4.SetTimerActive(true);
        gameObject.layer = 0;
        EnemySpawner();
        Destroy(gameObject, 15f);
        InvokeRepeating("EnemySpawner", 5, 5);
    }

    void Start()
    {
        GameObject radioExplosion = new GameObject("RadioExplosionSound");
        transform.SetParent(radioExplosion.transform);
        radioExplosionSound = radioExplosion.AddComponent<RadioExplosionSound>();
    }

    void EnemySpawner()
    {
        int random = Random.Range(0, enemiesDefenders.Count);
        Instantiate(enemiesDefenders[random], enemiesSpawn.transform.position, enemiesSpawn.transform.rotation);
    }

    void OnDestroy()
    {
        if (radioExplosionSound != null)
        {
            radioExplosionSound.PlaySound();
        }
    }
}
