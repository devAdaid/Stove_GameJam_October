using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
	[HideInInspector] public int stats_action = 0; //�׼�
	[HideInInspector] public int stats_horror = 0; //ȣ��
	[HideInInspector] public int stats_reasoning = 0; //�߸�
	[HideInInspector] public int stats_romance = 0; //�θǽ�
	[HideInInspector] public int stats_strength = 0; //����
	[HideInInspector] public int stats_fantasy = 0; //��Ÿ��

	public static PlayerStats instance = null;

	private void Awake() //�̱���
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(this.gameObject);
	}


	//public void Stats_Action_Up()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_action += a;
	//}
	//public void Stats_Action_Down()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_action -= a;
	//}
	//public void Stats_Horror_Up()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_horror += a;
	//}
	//public void Stats_Horror_Down()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_horror -= a;
	//}
	//public void Stats_Reasoning_Up()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_reasoning += a;
	//}
	//public void Stats_Reasoning_Down()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_reasoning -= a;
	//}
	//public void Stats_Romance_Up()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_romance += a;
	//}	
	//public void Stats_Romance_Down()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_romance -= a;
	//}
	//public void Stats_Strength_Up()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_strength += a;
	//}
	//public void Stats_Strength_Down()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_strength -= a;
	//}
	//public void Stats_Fantasy_Up()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_fantasy += a;
	//}
	//public void Stats_Fantasy_Down()
	//{
	//	int a = Random.Range(randomA, randomB);
	//	stats_fantasy -= a;
	//}
}
