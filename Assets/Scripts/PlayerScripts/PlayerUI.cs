using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    #region UI elements
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider mpBar;
    [SerializeField] private Text orbs;
    #endregion
    #region values
    private int orbValue;

    public int OrbValue { get => orbValue; set { orbValue = value; UpdateOrbs(); } }
    #endregion
    private void Awake() {
        healthBar.maxValue = 100;
        healthBar.value = healthBar.maxValue;
        mpBar.maxValue = 100;
        mpBar.value = mpBar.maxValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyBasics.sendOrbs += OrbAdd;
        HurtBox.sendDmg += HealthBarControl;
    }

    private void HealthBarControl(float val) {
        healthBar.value += val;
    }
    private void MpBarControl(float val) {
        mpBar.value += val;
    }
    private void OrbAdd(int val) {
        OrbValue += val;
    }
    private void UpdateOrbs() {
        orbs.text = "Orbs: "+orbValue.ToString();
    }
}
