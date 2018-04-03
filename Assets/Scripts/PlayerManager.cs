using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private Player currentPlayer;

	// public accessors
	public Player getCurrentPlayer(){
		return getInstance().currentPlayer;
	}
	public Player setCurrentPlayer(Player obj){
		//currentPlayer = obj;
		return getInstance().currentPlayer = obj;
	}

	//private functions
	private static PlayerManager instance;

	private PlayerManager(){
	}

	private static PlayerManager getInstance(){
		if (instance == null) {
			instance = new PlayerManager ();
		}
		return instance;
	}
}
