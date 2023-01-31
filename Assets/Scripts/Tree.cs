using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tree : MonoBehaviour
{
  
    public static Tree Instance { get; private set; }
    public int Health;
    [SerializeField] Slider HealthSlider;
    [SerializeField] GameObject losePanel;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Health = 100;
        HealthSlider.maxValue = Health;
        HealthSlider.value = Health;
    }
    public void GetDamage(int damageValue)
    {
        Health -= damageValue;
        if(Health<= 0)
        {
            losePanel.SetActive(true);
        }
        HealthSlider.value -= damageValue;
    }

}
