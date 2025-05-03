using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProtectionTxt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI protectionText;

    [SerializeField] PlayerBase playerBase;

    void Update()
    {
        if (playerBase != null)
        {
            protectionText.text = $"Proteccion: {playerBase.Protection}%";
        }
    }
}
