using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteBtn : MonoBehaviour
{
    public Toggle muteToggle; // Attach your UI Toggle component to this in the Inspector.

    private void Start()
    {
        // Initialize the muteToggle state based on PlayerPrefs.
        muteToggle.isOn = PlayerPrefs.GetInt("MuteState", 0) == 1;

        // Add an event listener to the toggle to detect state changes.
        muteToggle.onValueChanged.AddListener(OnMuteToggle);
    }

    // Handle the mute state toggle.
    private void OnMuteToggle(bool isMuted)
    {
        AudioListener.pause = isMuted; // Mute/unmute the audio.
        PlayerPrefs.SetInt("MuteState", isMuted ? 1 : 0); // Save the mute state.
        PlayerPrefs.Save(); // Save PlayerPrefs to disk.
    }
}
