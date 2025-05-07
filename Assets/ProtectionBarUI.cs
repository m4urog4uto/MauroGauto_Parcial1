using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectionBarUI : MonoBehaviour
{
    [SerializeField] Slider protectionSlider;
    [SerializeField] PlayerBase player;

    public void Update()
    {
        if (player != null && protectionSlider.value != player.Protection)
        {
            protectionSlider.value = player.Protection;
        }
    }
}
