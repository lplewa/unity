using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject tones;

    private bool coinsThrown;

    // Start is called before the first frame update
    void Start()
    {
      InventoryCanvas inventory = FindObjectOfType<InventoryCanvas>();
       if (inventory != null) Destroy(inventory.gameObject);
        state = BattleState.Start;
        StartCoroutine(SetupBattle());
        coinsThrown = false;
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
        coinsThrown = true;
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
            StartCoroutine(EnemyBellyAttack());
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
        StartCoroutine(EnemyThunderEyesAttack());
        Destroy(beard);
    }

    IEnumerator PlayerBlanketAttack()
    {
        SetButtonsActive(false);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        if (playerUnit.currentHealthPoints < playerUnit.maxHealthPoints)
        {
            playerUnit.currentHealthPoints += 1;
        }
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
            StartCoroutine(EnemyFourTonesAttack());
        }
    }

    IEnumerator PlayerCostureAttack()
    {
        SetButtonsActive(false);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        dialogueText.text = "Rzut kosturem!!!";
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
            StartCoroutine(EnemyThunderEyesAttack());
        }
    }

    void EndBattle()
    {
        if (state == BattleState.Won)
        {
            StartCoroutine(EnemyLostAnimation());
            dialogueText.text = "Dzieran pokonany!!!";
            StartCoroutine(MoveToNextScene());
        }
        else if(state==BattleState.Lost)
        {
            dialogueText.text = "Przegrałeś!";
            StartCoroutine(GoToLostScreen());
        }
    }

   IEnumerator GoToLostScreen()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("BattleLost");
    }

    IEnumerator MoveToNextScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("BaniaksPlayRoom Ending");
    }

    IEnumerator EnemyFourTonesAttack()
    {
        float tonesYPosition = tones.transform.position.y;
        DzieranHypnotizedEvent();
        dialogueText.text = enemyUnit.unitName + " i jego cztery tony nacisku!";
        enemyUnit.GetComponent<Animator>().SetBool("4tones", true);
        yield return new WaitForSeconds(1f);
        tones.SetActive(true);
        tones.GetComponent<Animator>().SetBool("4tones", true);
        yield return new WaitForSeconds(1.5f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHealthPoints(playerUnit.currentHealthPoints);
        tones.SetActive(false);
        enemyUnit.GetComponent<Animator>().SetBool("4tones", false);
        tones.transform.position = tones.transform.position + new Vector3(0f, -tonesYPosition, 0);
        StartCoroutine(PlayerDamageAnimation());
        yield return new WaitForSeconds(3f);
        SetNewBattleState(isDead);
    }

    IEnumerator EnemyBellyAttack()
    {
        float emeyYposition = enemyUnit.transform.position.y;
        DzieranHypnotizedEvent();
        dialogueText.text = enemyUnit.unitName + " atakuje brzuchem!";
        enemyUnit.GetComponent<Animator>().SetBool("bellyAttack", true);
        yield return new WaitForSeconds(1.8f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHealthPoints(playerUnit.currentHealthPoints);
        enemyUnit.GetComponent<Animator>().SetBool("bellyAttack", false);
        enemyUnit.transform.position = tones.transform.position + new Vector3(0f, -emeyYposition, 0);
        StartCoroutine(PlayerDamageAnimation());
        yield return new WaitForSeconds(3f);
        SetNewBattleState(isDead);
    }


    IEnumerator EnemyThunderEyesAttack()
    {
        DzieranHypnotizedEvent();
        dialogueText.text = enemyUnit.unitName + " piorunuje wzrokiem!";
        enemyUnit.GetComponent<Animator>().SetBool("eyeThunder", true);
        yield return new WaitForSeconds(3f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHealthPoints(playerUnit.currentHealthPoints);
        enemyUnit.GetComponent<Animator>().SetBool("eyeThunder", false);
        StartCoroutine(PlayerDamageAnimation());
        yield return new WaitForSeconds(3f);
        SetNewBattleState(isDead);
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
            if (isActive)
            {
                if (coinsThrown) button.interactable = true;
                else if (button.GetComponent<BattleButtons>().startButton) button.interactable = true;
                else button.interactable = false;
            }
            else button.interactable = false;
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

    IEnumerator PlayerDamageAnimation()
    {
        playerUnit.GetComponent<Animator>().SetBool("hit", true);
        yield return new WaitForSeconds(1f);
        playerUnit.GetComponent<Animator>().SetBool("hit", false);
        dialogueText.text = "Ałć!";
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

    IEnumerator EnemyLostAnimation()
    {
        enemyUnit.GetComponent<Animator>().SetTrigger("lose");
        yield return new WaitForSeconds(5f);
    }

    public void SetNewBattleState(bool isDead)
    {
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

}
