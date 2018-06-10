using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {
private int pointsOfInterestLevel;
private int haterLevel = 25;
private int neutralLevel = 50;
private int frindsLevel = 75;
private int loverLevel = 100;
	
public Text scoreText;
public Text freeText;
public GameObject happySam;
public GameObject annoyedSam;
public GameObject neutralSam;

	
	// Use this for initialization
	void Start () {
		pointsOfInterestLevel = GameStates.InterestLevel;
		
		scoreText.text = "You done it. You have " + pointsOfInterestLevel + " point so ...";
		happySam.SetActive(false);
		annoyedSam.SetActive(false);
		neutralSam.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		CalculateInterestLevel(pointsOfInterestLevel);
	}
	
	void CalculateInterestLevel(int _points){
		if(_points <= haterLevel){
			//The characters hate each other 
			freeText.text = "...she hates you and you won't see her again.";
			annoyedSam.SetActive(true);
		} else if (_points > haterLevel && _points <= neutralLevel){
			//The chars neighter hate nor like each other
			freeText.text = "...she don't know if she likes you or not. Maybe there will be another date.";
			neutralSam.SetActive(true);
		} else if(_points > neutralLevel && _points <= frindsLevel){
			//The chars are frinds
			freeText.text = "...you are good friends. You will meet her again to talk about your hobbies.";
			happySam.SetActive(true);
		} else{
			//The chars are lovers
			freeText.text = "...her love is so deep, she will stay with you forever.";
			happySam.SetActive(true);
		}
	}
}
