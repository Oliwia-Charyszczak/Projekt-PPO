using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public Image[] volumeParts;
    public float volume = 0.6f;
    public float volumeChangeAmount = 0.2f;
    void Start()
    {
        UpdateVolumeVisuals();
    }

    void UpdateVolumeVisuals()
    {
        if (volumeParts != null && volumeParts.Length > 0)
        {
            int imagesToShow = Mathf.RoundToInt(volume * volumeParts.Length);

            for (int i = 0; i < volumeParts.Length; i++)
            {
                volumeParts[i].enabled = i < imagesToShow;
            }
        }
    }


    public void IncreaseVolume()
    {
        volume = Mathf.Clamp01(volume + volumeChangeAmount);
        if (volume > 1.0f)
        {
            volume = 1.0f;
        }
        UpdateVolumeVisuals();
        AudioListener.volume = volume;
    }

    public void DecreaseVolume()
    {
        volume = Mathf.Clamp01(volume - volumeChangeAmount);
        if (volume < Mathf.Epsilon)
        {
            volume = 0.0f;
        }
        if (volume < 0.0000001f)
        {
            volume = 0.0f;
        }
        UpdateVolumeVisuals();
        AudioListener.volume = volume;

    }
}
