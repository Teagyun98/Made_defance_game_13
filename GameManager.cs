using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject Camera;
	public float mod;
	public GameObject ArrowBlue;
	public GameObject ArrowRed;
	public ParticleSystem MasicBlue;
	public ParticleSystem MasicRed;
	public GameObject UpgradeBW;
	public GameObject UpgradeBS;
	public GameObject UpgradeBA;
	public GameObject UpgradeBG;
	public GameObject Win;
	public GameObject Lose;
	public GameObject ReturnBtn;
	public GameObject Back;
	public GameObject BaseBlue;
	public GameObject BaseRed;
	public GameObject GameSet;

	private int MaxCost = 10;
	public int BlueCost=0;
	public int RedCost=0;

	bool AbleGetCostBlue = true;
	bool AbleGetCostRed = true;

	public int BlueHealth = 20;
	public int RedHealth = 20;

	public string GameOver;
	public bool PlayGame = false;
	public GameObject SoundManager;

	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		if (AbleGetCostBlue&&PlayGame)
			StartCoroutine(GetCostBlue());
		if (AbleGetCostRed&&PlayGame)
			StartCoroutine(GetCostRed());
		CheckUpgrade();
	}

	IEnumerator GetCostBlue() // 2초에 1씩 cost회복
	{
		AbleGetCostBlue = false;
		if (MaxCost > BlueCost)
			BlueCost++;
		yield return new WaitForSeconds(2f);
		AbleGetCostBlue = true;
	}

	IEnumerator GetCostRed()
	{
		AbleGetCostRed = false;
		if (MaxCost > RedCost)
			RedCost++;
		yield return new WaitForSeconds(mod);
		AbleGetCostRed = true;
	}

	void CheckUpgrade() //코스트가 10이 아니면 엑티브를 false로 설정
	{
		if (BlueCost == 10)
		{
			if (UpgradeBS != null)
				UpgradeBS.SetActive(true);
			if (UpgradeBA != null)
				UpgradeBA.SetActive(true);
			if (UpgradeBW != null)
				UpgradeBW.SetActive(true);
			if (UpgradeBG != null)
				UpgradeBG.SetActive(true);
		}
		if (BlueCost != 10)
		{
			if (UpgradeBS != null)
				UpgradeBS.SetActive(false);
			if (UpgradeBA != null)
				UpgradeBA.SetActive(false);
			if (UpgradeBW != null)
				UpgradeBW.SetActive(false);
			if (UpgradeBG != null)
				UpgradeBG.SetActive(false);
		}
	}

	public void End()
	{
		if (GameOver == "RedDie")
		{
			PlayGame = false;
			Win.SetActive(true);
			Back.SetActive(true);
			ReturnBtn.SetActive(true);
			GameSet.SetActive(false);

			for (int i = 0; i < BaseBlue.GetComponent<Base_Condition>().UnitList.Count; i++)
			{
				if (BaseBlue.GetComponent<Base_Condition>().UnitList[i]!=null)
					BaseBlue.GetComponent<Base_Condition>().UnitList[i].GetComponent<Unit>().enabled = false;
			}
			for (int i = 0; i < BaseRed.GetComponent<Base_Condition>().UnitList.Count; i++)
			{
				if (BaseRed.GetComponent<Base_Condition>().UnitList[i] != null)
					BaseRed.GetComponent<Base_Condition>().UnitList[i].GetComponent<Unit>().enabled = false;
			}
		}
		else if (GameOver == "BlueDie")
		{
			PlayGame = false;
			Lose.SetActive(true);
			Back.SetActive(true);
			ReturnBtn.SetActive(true);
			GameSet.SetActive(false);

			for (int i = 0; i < BaseBlue.GetComponent<Base_Condition>().UnitList.Count; i++)
			{
				if (BaseBlue.GetComponent<Base_Condition>().UnitList[i] != null)
					BaseBlue.GetComponent<Base_Condition>().UnitList[i].GetComponent<Unit>().enabled = false;
			}
			for (int i = 0; i < BaseRed.GetComponent<Base_Condition>().UnitList.Count; i++)
			{
				if (BaseRed.GetComponent<Base_Condition>().UnitList[i] != null)
					BaseRed.GetComponent<Base_Condition>().UnitList[i].GetComponent<Unit>().enabled = false;
			}
		}
	}
}
