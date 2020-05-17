using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {Start, PlayerTurn, EnemyTurn, Won, Lost}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    
    public  Unit playerUnit;
    public  Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Text dialogueText;
    public List<Button> attackButtons;

    public GameObject coinsButton;
    public GameObject beardButton;
    public GameObject costureButton;
    public GameObject apartButton;
    public GameObject blanketButton;

    public GameObject costure;

    // Start is called before the first frame update
    void Start()
    {
      InventoryCanvas inventory = FindObjectOfType<InventoryCanvas>();
       if (inventory != null) Destroy(inventory.gameObject);
        state = BattleState.Start;
        StartCoroutine(SetupBattle());
    }

     IEnumerator SetupBattle()
    {
        SetButtonsActive(false);
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

   
    void PlayerTurn()
    {
        dialogueText.text = "Może by tak...";
        SetButtonsActive(true);
    }

    public void OnCoinsAttackButton()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerCoinsAttack());
        RemoveButton(coinsButton);
    }

    public void OnApartAttackButton()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerApartAttack());
        RemoveButton(apartButton);
    }

    public void OnBeardAttackButton()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerBeardAttack());
        RemoveButton(beardButton);
    }

    public void OnBlanketAttackButton()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerBlanketAttack());
        RemoveButton(blanketButton);
    }

    public void OnCostureAttackButton()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerCostureAttack());
        RemoveButton(costureButton);
    }

    IEnumerator PlayerCoinsAttack()
    {
        SetButtonsActive(false);
        dialogueText.text = "Dzieran liczy monety! Kolejna moja tura!";
        yield return new WaitForSeconds(2f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    IEnumerator PlayerApartAttack()
    {
        SetButtonsActive(false);
        bool isDead=enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        dialogueText.text = "Plaskacz z apartu raz!";
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator PlayerBeardAttack()
    {
        SetButtonsActive(false);
        dialogueText.text = "Epicki rzut brodą...";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Chyba nie zadziałało...";
        state = BattleState.EnemyTurn;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerBlanketAttack()
    {
        SetButtonsActive(false);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        playerUnit.currentHealthPoints += 2;
        dialogueText.text = "Poczuj ciepło tego koca!";
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        playerHUD.SetHealthPoints(playerUnit.currentHealthPoints);
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerCostureAttack()
    {
        SetButtonsActive(false);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        dialogueText.text = "Kostur leci!!!";
        costure.SetActive(true);
        costure.GetComponent<Animator>().SetBool("costure", true);
        yield return new WaitForSeconds(1.1f);
        Destroy(costure);
        if (isDead)
        {
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()
    {
        if (state == BattleState.Won)
        {
            dialogueText.text = "Pokonałeś przeciwnika!!!";
        }
        else if(state==BattleState.Lost)
        {
            dialogueText.text = "Przegrałeś!";
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " atakuje";
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHealthPoints(playerUnit.currentHealthPoints);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            state = BattleState.Lost;
            EndBattle();
        }
        else
        {
            state = BattleState.PlayerTurn;
            PlayerTurn();
        }
    }

    private void RemoveButton(GameObject button)
    {
        Destroy(button);
        attackButtons.Remove(button.GetComponent<Button>());
    }

    private void SetButtonsActive(bool isActive)
    {
        foreach (Button button in attackButtons)
        {
            button.interactable = isActive;
        }
    }
}
