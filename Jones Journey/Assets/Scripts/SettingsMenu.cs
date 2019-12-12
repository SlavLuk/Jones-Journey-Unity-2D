using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer musicMixer;
    [SerializeField]
    private Slider musicSlider; 
    [SerializeField]
    private TMP_Dropdown dropdown;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

      

        //Add listener for when the value of the Dropdown changes, to take action
        dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdown);
        });


    }


    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMP_Dropdown change)
    {
  
        QualitySettings.SetQualityLevel(change.value, true);
        
       
    }
   

    public void SetMusicVolume()
    {
        float sliderValue = musicSlider.value;
        musicMixer.SetFloat("volume", sliderValue/ 2);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);

     
    }

}
