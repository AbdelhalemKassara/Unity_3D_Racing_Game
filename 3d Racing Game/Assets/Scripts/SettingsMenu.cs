using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();//creates a new list that stores strings called options
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)// loops through each element in the resolutions array
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;//declairs a new variable called option and stores the (width x height)
            options.Add(option);// 

            if (resolutions[i].width == Screen.currentResolution.width
            && resolutions[i].height == Screen.currentResolution.height)// comparing the width and the height of current screen resolution with each of the available resolutions
            {
                currentResolutionIndex = i; // when they are the same set the currentresolutionIndex variable equal to i
            }
        }

        resolutionDropdown.AddOptions(options);// add all the options to the resolution drop down
        resolutionDropdown.value = currentResolutionIndex;// set the game resolution equal to the current resolution
        resolutionDropdown.RefreshShownValue();// refresh the dropdown to display the current resolution
    }

    public void SetVolume(float volume)// takes in the volume or the position of the slider
    {
        audioMixer.SetFloat("volume", volume);// calles the audio mixer and sets the value of the slider equal to the value of the audio mixer
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);// 
    }
    public void SetFullScreen(bool isFullScreen)
    {

        Screen.fullScreen = isFullScreen;// sets the state of the button (boolean) equal to the fullscreen option in the unity engine 
    }
    public void SetResolution (int resolutionIndex){// inputs the index of the selected resolution on the drop down
        Resolution resolution = resolutions[resolutionIndex];//creates a new variable called resolution that will store the selected resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);// sets the current resolution equal to the resolution stored in the variable called resolution
    }
}
