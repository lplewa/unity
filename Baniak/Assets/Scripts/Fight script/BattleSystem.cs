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
    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        StartCoroutine(SetupBattle());
    }

     IEnumerator SetupBattle()
    {
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Może by tak...";
    }

   public void OnAttack1Button()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerAttack1());
    }

    public void OnAttack2Button()
    {
        if (state != BattleState.PlayerTurn) return;
        StartCoroutine(PlayerAttack2());
    }

    IEnumerator PlayerAttack1()
    {
        bool isDead=enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        dialogueText.text = "Zaatakowano na bogato";
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

    IEnumerator PlayerAttack2()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHealthPoints(enemyUnit.currentHealthPoints);
        dialogueText.text = "Zaatakowano na bogato";
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
}
