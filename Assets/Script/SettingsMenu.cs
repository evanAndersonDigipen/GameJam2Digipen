﻿////////////////////////////
/// By: Gavin C
/// Date: 1/5/2021
/// Desription: This is a script for the settings menu
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Tooltip("The audio mixer for the game.")]
    public AudioMixer Mixer;
    [Tooltip("The resolution dropdown.")]
    public Dropdown ResolutionDropdown;


    Resolution[] Resolutions;


    //Set up the resolution dropdown
    void Start()
    {
        if (ResolutionDropdown)
        {
            //set up resolution and clear dropdown
            Resolutions = Screen.resolutions;
            ResolutionDropdown.ClearOptions();

            //list to store dropdown options
            List<string> DropdownOptions = new List<string>();

            //add each resolution to the list
            int CurrentResolutionIndex = 0;
            for (int i = 0; i < Resolutions.Length; i++)
            {
                string Option = Resolutions[i].width + " x " + Resolutions[i].height;
                DropdownOptions.Add(Option);

                if (Resolutions[i].width == Screen.currentResolution.width && Resolutions[i].height == Screen.currentResolution.height)
                {
                    CurrentResolutionIndex = i;
                }
            }

            //set the dropdown to the list
            ResolutionDropdown.AddOptions(DropdownOptions);

            //Set resolution
            ResolutionDropdown.value = CurrentResolutionIndex;
            ResolutionDropdown.RefreshShownValue();
        }
    }


    //Function to change resolution
    public void SetResolution(int ResolutionIndex)
    {
        Resolution Resolution = Resolutions[ResolutionIndex];
        Screen.SetResolution(Resolution.width, Resolution.height, Screen.fullScreen);
    }


    //Function to set volume
    public void SetVolume(float volume)
    {
        Mixer.SetFloat("volume", volume);
        Debug.Log("Set volume: " + volume);
    }


    //Function to set fullscreen
    public void SetFullscreen(bool IsFullscreen)
    {
        Screen.fullScreen = IsFullscreen;
        Debug.Log("Change fullscreen to: " + IsFullscreen);
    }
}
