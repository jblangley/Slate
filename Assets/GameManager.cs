using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    PlayerController gO;
    public GameObject[] allUnits;
    Spawner spawner;

    [SerializeField]
    CardGridHandler cardGridHandler;
    [SerializeField]
    PauseMenu pauseMenu;
    [SerializeField]
    UnitSelectMenu unitSelectMenu;

    public event Action EvTakeTurn;

    [SerializeField]
    List<GameObject> teamOne;
    [SerializeField]
    List<GameObject> teamTwo;

    void Start()
    {
        allUnits = GameObject.FindGameObjectsWithTag("Unit");
        SeperateTeams();
    }

    void SeperateTeams()
    {
        foreach (GameObject unit in allUnits)
        {
            UnitBaseStats unitStats = unit.GetComponent<UnitBaseStats>();
            if (unitStats.kingdomID == 0)
            {
                teamOne.Add(unit);
            }
            if (unitStats.kingdomID == 1)
            {
                teamTwo.Add(unit);
            }
        }
    }

    public void SelectUnit(Deck deck)
    {
        gO = deck.GetComponent<PlayerController>();
        cardGridHandler.ChangeSelectedUnit(deck);
    }

    public void SelectSpawner(Spawner _spawner)
    {
        unitSelectMenu.EnableMenu(_spawner);
    }

    public void SelectTarget(GameObject obj)
    {
        gO.SetTargetPath(obj);
    }

    public void SelectPoint(Vector3 point)
    {
        gO.SetTargetPath(point);
    }

    public void TargetUnit(GameObject target, CardDisplay card)
    {
        if (target.gameObject.tag == "Unit"
            && OnSameTeam(gO.GetComponent<UnitBaseStats>(),
            target.GetComponent<UnitBaseStats>())
            == card.card.GetTargetType())
        {
            gO.SetTargetPath(target); 
            gO.GetComponent<Combat>().SetCard(card.card);//Combat combat =
            //combat.SetCard(card.card);
            cardGridHandler.PlayCard(card);
        }
    }

    public void NextAction()
    {
        EvTakeTurn();
        CheckWin();
    }

    public bool CheckWin()
    {
        teamOne.RemoveAll(item => item == null);
        teamTwo.RemoveAll(item => item == null);
        if (teamOne.Count == 0)
        {
            Debug.Log("Team Two Wins!");
            pauseMenu.WinDisplay("Team Two Wins!");
            return false;
        }
        if (teamTwo.Count == 0)
        {
            Debug.Log("Team One Wins!");
            pauseMenu.WinDisplay("Team One Wins!");
            return true;
        }
        return false;
    }

    public TargetType OnSameTeam(UnitBaseStats one, UnitBaseStats two)
    {
        if (one.kingdomID == two.kingdomID)
        {
            return TargetType.Ally;
        }
        return TargetType.Enemy;
    }
}
