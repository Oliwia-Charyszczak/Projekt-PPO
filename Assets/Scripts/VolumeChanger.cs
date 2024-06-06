using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public Image[] volumeParts;
    public float volume = 1f;
    public float volumeChangeAmount = 0.2f;

    private static VolumeChanger instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        SaveVolumeData();
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
        SaveVolumeData();
        AudioListener.volume = volume;

    }
    public void SaveVolumeData()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void LoadVolumeData()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
            UpdateVolumeVisuals();
            AudioListener.volume = volume;
        }
    }
}
