using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider healthPointsSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        healthPointsSlider.maxValue = unit.maxHealthPoints;
        healthPointsSlider.value = unit.currentHealthPoints;
    }

    public void SetHealthPoints(int healthPoints)
    {
        healthPointsSlider.value = healthPoints;
    }
}
