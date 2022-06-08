using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Settings;
    public Slider MASTER_SLIDER;
    public Slider BGM_SLIDER;
    public Slider SFX_SLIDER;
    public Text Title;
    public Text MASTER_VAL;
    public Text BGM_VAL;
    public Text SFX_VAL;

    //
    //public Slider[] SLIDERS;
    //public List<Slider> SLIDERS = new List<Slider>();
    public Dictionary<string, Slider> SLIDERS = new Dictionary<string, Slider>();

    private static MenuManager instance = null;

    #region Initialize
    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (MenuManager)FindObjectOfType(typeof(MenuManager));
                if (instance == null)
                    instance = (new GameObject("MenuManager")).AddComponent<MenuManager>();
            }

            return instance;
        }
    }

    private void Init()
    {
        Menu = GameObject.Find("Menu (Canvas)");
        Title = GameObject.Find("Title (Text)").GetComponent<Text>();
        Settings = GameObject.Find("Settings");

        MASTER_SLIDER = GameObject.Find("MASTER (Slider)").GetComponent<Slider>();
        //SLIDERS.Add(MASTER_SLIDER);
        SLIDERS.Add("MASTER", MASTER_SLIDER);
        MASTER_VAL = GameObject.Find("MASTER Value (Text)").GetComponent<Text>();
        
        BGM_SLIDER = GameObject.Find("BGM (Slider)").GetComponent<Slider>();
        //SLIDERS.Add(BGM_SLIDER);
        SLIDERS.Add("BGM", BGM_SLIDER);
        BGM_VAL = GameObject.Find("BGM Value (Text)").GetComponent<Text>();

        SFX_SLIDER = GameObject.Find("SFX (Slider)").GetComponent<Slider>();
        //SLIDERS.Add(SFX_SLIDER);
        SLIDERS.Add("SFX", SFX_SLIDER);
        SFX_VAL = GameObject.Find("SFX Value (Text)").GetComponent<Text>();
    }

    #endregion

    private void Start()
    {
        Init();
    }

}
