using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGauge : MonoBehaviour {

    #region money

    [Header("Money")]

    [SerializeField]
    [Tooltip("Texte qui affichera la quantité d'argent.")]
    private UnityEngine.UI.Text moneyDisplayer;

    [Tooltip("Quantité d'argent actuelle.")]
    public int money = 0;

    #endregion

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
