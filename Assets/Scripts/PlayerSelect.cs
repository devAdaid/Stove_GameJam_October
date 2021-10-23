using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerStats //스텟
{
	action,
	horror,
	reasoning,
	romance,
	strength,
	fantasy
}
public enum UpDown //스텟 올리거나 내리거나
{
	Up,
	Down
}

public class PlayerSelect : MonoBehaviour
{
	public EPlayerStats stats;
	public UpDown updown;

	[SerializeField] private int randomA;
	[SerializeField] private int randomB;

	public PlayerStats playerStats;

	private void Start()
	{
		playerStats = GameObject.Find("GameStats").GetComponent<PlayerStats>();
	}

	public void Stats_Action()
	{
		if (stats == EPlayerStats.action && updown == UpDown.Up)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_action += a;
		}
		else if (stats == EPlayerStats.action && updown == UpDown.Down)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_action -= a;
		}
	}
	public void Stats_Horror()
	{
		if (stats == EPlayerStats.horror && updown == UpDown.Up)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_horror += a;
		}
		else if (stats == EPlayerStats.horror && updown == UpDown.Down)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_horror -= a;
		}
	}
	public void Stats_Reasoning()
	{
		if (stats == EPlayerStats.reasoning && updown == UpDown.Up)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_reasoning += a;
		}
		else if (stats == EPlayerStats.reasoning && updown == UpDown.Down)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_reasoning -= a;
		}
	}
	public void Stats_Romance()
	{
		if (stats == EPlayerStats.romance && updown == UpDown.Up)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_romance += a;
		}
		else if (stats == EPlayerStats.romance && updown == UpDown.Down)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_romance -= a;
		}
	}
	public void Stats_Strength()
	{
		if (stats == EPlayerStats.strength && updown == UpDown.Up)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_strength += a;
		}
		else if (stats == EPlayerStats.strength && updown == UpDown.Down)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_strength -= a;
		}
	}
	public void Stats_Fantasy()
	{
		if (stats == EPlayerStats.fantasy && updown == UpDown.Up)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_fantasy += a;
		}
		else if (stats == EPlayerStats.fantasy && updown == UpDown.Down)
		{
			int a = Random.Range(randomA, randomB);
			PlayerStats.instance.stats_fantasy -= a;
		}
	}
	public int Stats_SUM()
	{
		int a = PlayerStats.instance.stats_action + PlayerStats.instance.stats_horror + PlayerStats.instance.stats_reasoning + PlayerStats.instance.stats_romance + PlayerStats.instance.stats_strength + PlayerStats.instance.stats_fantasy;
	return a;
	}
		
}
