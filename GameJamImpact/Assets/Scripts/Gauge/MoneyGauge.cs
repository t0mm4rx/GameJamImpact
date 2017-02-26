using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyGauge : MonoBehaviour {

    #region money

    [Header("Money")]

    [SerializeField]
    [Tooltip("Tag de l'UI qui affiche l'argent.")]
    private string coinMeterTag;
    
    [Tooltip("Texte qui affichera la quantité d'argent.")]
    private UnityEngine.UI.Text moneyDisplayer = null;

    [Tooltip("Quantité d'argent actuelle.")]
    public int money = 0;

    #endregion

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    public void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject coinMeter = GameObject.FindGameObjectWithTag(coinMeterTag);
        if (coinMeter != null)
        {
            moneyDisplayer = coinMeter.GetComponent<Text>();
        }
    }

    public void Display()
    {
        if(moneyDisplayer != null)
            moneyDisplayer.text = "Argent : " + money + " $";
    }

    public static MoneyGauge operator +(MoneyGauge mg, int m)
    {
        mg.money = Mathf.Max(mg.money + m, 0);
        return mg;
    }

    public static explicit operator int(MoneyGauge mg)
    {
        return mg.money;
    }
}
