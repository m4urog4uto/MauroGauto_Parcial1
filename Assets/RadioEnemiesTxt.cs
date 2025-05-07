using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioEnemiesTxt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI radioEnemiesTx;
    [SerializeField] RadioSpawner radiosSpawners;

    void Update()
    {
        radioEnemiesTx.text = $"{radiosSpawners.CurrentRadiosDestroyed}/{radiosSpawners.TotalRadiosEnemies}";
    }
}
