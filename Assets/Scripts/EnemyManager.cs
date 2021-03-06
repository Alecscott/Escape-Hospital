﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	private Enemy currentEnemy;

	// public accessors
	public Enemy getCurrentEnemy(){
		return getInstance().currentEnemy;
	}
	public Enemy setCurrentEnemy(Enemy obj){
		//currentPlayer = obj;
		return getInstance().currentEnemy = obj;
	}

	//private functions
	private static EnemyManager instance;

	private EnemyManager(){
	}

	private static EnemyManager getInstance(){
		if (instance == null) {
			instance = new EnemyManager ();
		}
		return instance;
	}
}
