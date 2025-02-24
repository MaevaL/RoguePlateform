﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateShopUI : MonoBehaviour {

    [SerializeField]
    private Text fireRate;
    [SerializeField]
    private Text maxEnergy;
    [SerializeField]
    private Text neededEnergy;
    [SerializeField]
    private Text currentEnergy;
    [SerializeField]
    private Text maxLife;
    [SerializeField]
    private Text fireDamage;
    [SerializeField]
    private Text punchDamage;
    [SerializeField]
    private Text punchRate;
    //Other Graphics
    [SerializeField]
    private Button yourButton;
    [SerializeField]
    private Canvas hudUpgrade;

    public GameObject player;

    //Controller 
    private UpgradeController upgradeController;
    private GoldController goldController;
    private LifeController lifeController;
    private FireController fireController;
    private AttackTriggerController attackTriggerController;
    private PlayerController playerController;
    private MeleeController meleeController;

    private bool shopDisabled;


    void Start() {
        //Get All Controller 

        player = GameObject.FindGameObjectWithTag("Player");
        upgradeController = player.GetComponent<UpgradeController>();
        goldController = player.GetComponent<GoldController>();
        lifeController = player.GetComponent<LifeController>();
        fireController = player.GetComponent<FireController>();
        playerController = player.GetComponent<PlayerController>();
        meleeController = player.GetComponent<MeleeController>();

        playerController.SetShopDisabled(false);

        Hud();
  
        //Create Listener EXIT 
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(Exit);
    }

    void Update() {
        Hud();
    }

    private void Hud() {
        //Update all text fields 
        neededEnergy.text = "Energy needed for next upgrade : " + upgradeController.GetCost();
        currentEnergy.text = "Current Energy : " + goldController.GetEnergy() + "/" + goldController.GetEnergyMax();
        maxLife.text = "" + lifeController.GetLifeMax();
        fireRate.text = "each " + fireController.GetFireRate() + " sec";
        maxEnergy.text = "" + goldController.GetEnergyMax();
        fireDamage.text = "" + playerController.GetDamageProjectile();
        punchDamage.text = "" + playerController.GetDamageMelee();
        punchRate.text = "each " + meleeController.GetAttackCooldown() + " sec";
    }

    private void Exit() {
        //Disable the HUD UPGRADE
        hudUpgrade.gameObject.SetActive(false);
        playerController.SetShopDisabled(true);
        Debug.Log("Shop is now Disabled");
    }
}
