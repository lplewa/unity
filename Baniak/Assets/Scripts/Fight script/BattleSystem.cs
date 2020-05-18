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
    public GameObject blanket;
    public GameObject apart;
    public GameObject beard;
    public GameObject coins;

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
        coins.SetActive(true);
        coins.GetComponent<Animator>().SetBool("coins", true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyCoinHypnotizedAnimation());
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
        apart.SetActive(true);
        apart.GetComponent<Animator>().SetBool("apart", true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyDamageAnimation());
        Destroy(apart);
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
        dialogueText.text = "Epicki rzut brodą!";
        beard.SetActive(true);
        beard.GetComponent<Animator>().SetBool("beard", true);
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Ups... Chyba nie zadziałało...";
        yield return new WaitForSeconds(1.5f);
        state = BattleState.EnemyTurn;
        StartCoroutine(EnemyTurn());
        Destroy(beard);
    }

    IEnumerator PlayerBlanketAttack()
    {
        SetButtonsActive(false);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        playerUnit.currentHealthPoints += 2;
        dialogueText.text = "Poczuj ciepło tego koca!";
        blanket.SetActive(true);
        blanket.GetComponent<Animator>().SetBool("blanket", true);
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        playerHUD.SetHealthPoints(playerUnit.currentHealthPoints);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(EnemyDamageAnimation());
        Destroy(blanket);
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
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(EnemyDamageAnimation());
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
        DzieranHypnotizedEvent();
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

    
IEnumerator EnemyDamageAnimation()
    {
        DzieranHypnotizedEvent();
        enemyUnit.GetComponent<Animator>().SetBool("hit", true);
        dialogueText.text = "Musiało boleć";
        yield return new WaitForSeconds(1.5f);
        enemyUnit.GetComponent<Animator>().SetBool("hit", false);
    }

    private void DzieranHypnotizedEvent()
    {
        bool isHypnotized = enemyUnit.GetComponent<Animator>().GetBool("coinHypnotized");
        if (isHypnotized)
        {
            Destroy(coins);
            enemyUnit.GetComponent<Animator>().SetBool("coinHypnotized", false);
        }
    }

    IEnumerator EnemyCoinHypnotizedAnimation()
    {
        enemyUnit.GetComponent<Animator>().SetBool("coinHypnotized", true);
        yield return new WaitForSeconds(1.5f);
    }
}
