using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //private List<Slider> _SLIDERS = new List<Slider>();
    //Dictionary<string, BadGuy> badguys = new Dictionary<string, BadGuy>();
    private Dictionary<string, Slider> _SLIDERS = new Dictionary<string,Slider>();
    private Slider _MASTERslider;
    private Slider _BGMslider;
    private Slider _SFXslider;

    private float _MASTERsliderValue;
    private float _BGMsliderValue;
    private float _SFXsliderValue;
    private float _sliderValue;

    public List<ResItem> resolutions = new List<ResItem>();

    // Start is called before the first frame update
    void Start()
    {
        _SLIDERS = MenuManager.Instance.SLIDERS;

        _BGMslider = MenuManager.Instance.BGM_SLIDER;
        _SFXslider = MenuManager.Instance.SFX_SLIDER;
        _MASTERslider = MenuManager.Instance.MASTER_SLIDER;

        _MASTERsliderValue = _MASTERslider.value;
        _BGMsliderValue = _BGMslider.value;
        _SFXsliderValue = _SFXslider.value;

        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slider(string type)
    {
        _BGMsliderValue = _BGMslider.value;
        _SFXsliderValue = _SFXslider.value;
        _MASTERsliderValue = _MASTERslider.value;

        switch (type)
        {
            case "MASTER":
                //_SLIDERS.GetType()
                MenuManager.Instance.MASTER_VAL.text = _MASTERsliderValue.ToString("0.##") + "%";
                //AudioListener.volume = _BGMsliderValue;
                AudioManager.Instance.AudioMix.SetFloat("MasterVolume", Mathf.Log10(_MASTERsliderValue * 20));
                Debug.Log("DEBUG TEST" + Mathf.Log10(_MASTERsliderValue * 20));
                _sliderValue = _MASTERsliderValue;
                break;
            case "BGM":
                MenuManager.Instance.BGM_VAL.text = _BGMsliderValue.ToString("0.##") + "%";
                //AudioListener.volume = _BGMsliderValue;
                AudioManager.Instance.AudioMix.SetFloat("BGMVolume", Mathf.Log10(_BGMsliderValue * 20));
                _sliderValue = _BGMsliderValue;
                break;
            case "SFX":
                MenuManager.Instance.SFX_VAL.text = _SFXsliderValue.ToString("0.##") + "%";
                //AudioListener.volume = _SFXsliderValue;
                AudioManager.Instance.AudioMix.SetFloat("SFXVolume", Mathf.Log10(_SFXsliderValue * 20));
                _sliderValue = _SFXsliderValue;
                break;
            default:
                break;
        }

        PlayerPrefs.SetFloat(type + "_Volume", _sliderValue);

    }

    void LoadValues()
    {
        _MASTERsliderValue = PlayerPrefs.GetFloat("MasterVolume");
        _SFXsliderValue = PlayerPrefs.GetFloat("SFXVolume");
        _BGMsliderValue = PlayerPrefs.GetFloat("BGMVolume");

        _BGMslider.value = _BGMsliderValue;
        _SFXslider.value = _SFXsliderValue;
        _MASTERslider.value = _MASTERsliderValue;
        //AudioListener.volume = _BGMsliderValue;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}