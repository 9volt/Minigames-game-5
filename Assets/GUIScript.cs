using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {
	private int phase = 0;
	private string type = "Baby Green Dragon";
	private int radiationlvl;
	private int ragelvl;
	private int magiclvl;
	private int darknesslvl;
	private int ice = 0;
	private int sky= 0;
	private int fire = 0;
	private int forest= 0;
	private int hunger = 0;
	public SpriteRenderer dragon;
	Sprite[] s;
	//static int dragon_collection = 1;
	//int[] dragon_types = {137, 139,552, 554, 537, 539, 85, 375, 498, 531, 191, 141, 142, 182, 382, 627, 164, 380,630, 120, 105,622, 201};
	static List<int> dragon_collection; 

	// Use this for initialization
	void Start () {
		s = Resources.LoadAll<Sprite>("tiles");
		if (dragon_collection == null){
			dragon_collection = new List<int>{137, 138, 139,552, 554, 537, 539, 85,377, 375, 498, 531, 191, 141, 142, 182, 382, 627, 164, 380,630, 120, 105,622, 201};
		}
	}


	
	// Update is called once per frame
	void Update () {

	}

	void changeDragon(int x){
		dragon.sprite = s[x];
		if (dragon_collection.IndexOf(x) > -1){
			dragon_collection.Remove(x);
		}
	}
	
	void OnGUI(){
		GUI.Label (new Rect(200,Screen.height - 40, 300, 70),
		          "You've discovered " + (26 - (dragon_collection.Count ) ) + " out of 26 dragons!");

		if (phase < 4){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Feed.")){
				hunger = hunger -2;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Take a stroll at night.")){
				hunger += 1;
				darknesslvl +=2;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-60, 200, 20), "Attack training dummies.")){
				ragelvl+=1;
				hunger+=1;
				phase +=1;
			}if (GUI.Button(new Rect(220, Screen.height-100, 200, 20), "Bath the dragon in the river.")){
				radiationlvl +=1;
				hunger +=1;
				phase +=1;
			}
			if (GUI.Button(new Rect(220, Screen.height-80, 200, 20), "Bring the dragon a treasure.")){
				magiclvl +=1;
				hunger += 1;
				phase +=1;
			}
			if (GUI.Button(new Rect(220, Screen.height-60, 200, 20), "Let the dragon sleep")){
				phase +=1;
			}
		}else if(phase ==4){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if(hunger >=4){
				type = "Man-Like Dragon";
				changeDragon(377);
			}else if(radiationlvl >= 3){
				type = "Hydra";
				changeDragon(137);
			}else if(darknesslvl >= 3){
				type = "Dark Dragon";
				changeDragon(85);
			}else if(magiclvl >= 2){
				type = "White Dragon";
				changeDragon(191);
			}else if(ragelvl >= 3){
				type = "Purple Dragon";
				changeDragon(164);
			}else{
				type = "Man-Like Dragon";
				changeDragon(377);
			}if (GUI.Button(new Rect(220, Screen.height-60, 200, 20), "Let the dragon sleep")){
				phase +=1;
			}
		}else if(phase >=4 && phase < 10 && type == "Man-Like Dragon" ){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Feed.")){
				hunger = hunger -2;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Study books and history.")){
				hunger += 1;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-60, 200, 20), "Travel in the forest.")){
				forest+=1;
				hunger+=1;
				phase +=1;
			}
		}else if(phase == 10 && type == "Man-Like Dragon"){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				if(hunger >=4 || forest < 3){
					type = "Pacifist Dragon";
					changeDragon(627);
					phase+=1;
				}else{
					forest = 0;
					type = "Green Dragon";
					changeDragon(105);
					phase+=1;
				}
		}else if(phase != 10 && type == "Hydra" ){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Feed.")){
				hunger = hunger -2;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Bath in the river.")){
				hunger += 1;
				radiationlvl +=1;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-60, 200, 20), "Travel in the forest.")){
				hunger+=1;
				phase +=1;
			}
		}else if(phase != 10 && type == "Dark Dragon" ){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Feed.")){
					hunger = hunger -2;
					phase +=1;
				}
				if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Bathe in the moonlight.")){
					hunger += 1;
					phase +=1;
				}
		}else if(phase != 10 && type == "White Dragon" ){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Feed.")){
				hunger = hunger -2;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Study Magical Objects.")){
				hunger += 1;
				magiclvl +=1;
				phase +=1;
			}
		}else if(phase != 10 && type == "Purple Dragon" ){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Feed.")){
					hunger = hunger -2;
					phase +=1;
				}
				if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Go hunting for small animals.")){
					hunger += 1;
					ragelvl +=1;
					phase +=1;
				}
	   }else if(phase == 10 && type == "Hydra"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if(hunger >=6){
				type = "Skeletal Hydra";
				changeDragon(537);
				phase+=1;
			}else if(radiationlvl >= 6){
				type = "Radioactive Hydra";
				changeDragon(552);
				phase+=1;
			}else{
				type = "Green Hydra";
				changeDragon(138);
				phase+=1;
			}
		}else if(phase == 10 && type == "Dark Dragon"){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				if(hunger < 6){
					type = "Dark Man-Like Dragon";
					changeDragon(375);
					phase+=1;
				}else{
					type = "Skeletal Dragon";
					changeDragon(498);
					phase+=1;
				}
		}else if(phase == 10 && type == "White Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if(magiclvl < 7){
				type = "White Man-Like Dragon";
				changeDragon(382);
				phase+=1;
			}else{
				type = "Magic Dragon";
				changeDragon(141);
				phase+=1;
			}
		}else if(phase == 10 && type == "Purple Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if(hunger > 4){
				type = "Purple Man-Like Dragon";
				changeDragon(380);
				phase+=1;
			}else{
				type = "Blood Dragon";
				changeDragon(630);
				phase+=1;
			}
		}else if(type == "Pacifist Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			GUI.Label (new Rect(20,50, 300, 70),
			           "Your dragon has become a  " + type  + " and refuses to fight for you. He is leaving to study with the humans.");
			if (GUI.Button(new Rect(220, Screen.height-60, 200, 20), "Play Again?")){
				Application.LoadLevel("dontreallycare");
			}
		}else if(phase == 15 && type == "Green Hydra"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Greater Green Hydra";
			changeDragon(139);
			phase+=1;
		
		}else if(phase == 15 && type == "Radioactive Hydra"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Greater Radioactive Hydra";
			changeDragon(554);
			phase+=1;
			
		}else if(phase == 15 && type == "Skeletal Hydra"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Greater Skeletal Hydra";
			changeDragon(539);
			phase+=1;
		}else if(phase == 15 && type == "Skeletal Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Greater Skeletal Dragon";
			changeDragon(531);
			phase+=1;
		}else if(phase == 15 && type == "Dark Man-Like Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Pacifist Dragon";
			changeDragon(627);
			phase+=1;
		}else if(phase == 15 && type == "White Man-Like Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Pacifist Dragon";
			changeDragon(627);
			phase+=1;
		}else if(phase == 15 && type == "Purple Man-Like Dragon"){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				type = "Pacifist Dragon";
				changeDragon(627);
				phase+=1;
		}else if(phase == 15 && type == "Blood Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			type = "Great Golden Blood Dragon";
			changeDragon(120);
			phase+=1;
	 	}else if(phase == 15 && type == "Magic Dragon"){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
			if (sky > ice){
				type = "Great Sky Dragon";
				changeDragon(182);
			}else{
				type = "Great Ice Dragon";
				changeDragon(142);
			}
			phase+=1;
		}else if(phase == 15 && type == "Green Dragon"){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				if (fire > forest){
					type = "Great Fire Dragon";
					changeDragon(622);
				}else{
					type = "Great Forest Dragon";;
					changeDragon(201);
			}
				phase+=1;
		}else if(type == "Green Hydra"){
				GUI.Label (new Rect(20,20, 300, 70),
				           "Week " + phase  + " Type " + type);
				if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Train.")){
					hunger = hunger -2;
					phase +=1;
				}
		}else if(type == "Dark Man-Like Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Read.")){
				hunger = hunger -2;
				phase +=1;
			}
		}else if(type == "White Man-Like Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Read.")){
				hunger = hunger -2;
				phase +=1;
			}
		}else if(type == "Purple Man-Like Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Read.")){
				hunger = hunger -2;
				phase +=1;
			}
		}else if(type == "Magic Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Study Ice Magic.")){
				ice += 1;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Study Sky Magic.")){
				sky +=1;
				phase +=1;
			}
		}else if(type == "Green Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Visit the Volcano.")){
				fire += 1;
				phase +=1;
			}
			if (GUI.Button(new Rect(20, Screen.height-80, 200, 20), "Visit the Forests.")){
				forest +=1;
				phase +=1;
			}
		}else if(type == "Radioactive Hydra"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Train.")){
				hunger = hunger -2;
				phase +=1;
				}
		}else if(type == "Skeletal Hydra"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Train.")){
				hunger = hunger -2;
				phase +=1;
			}
		}else if(type == "Skeletal Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Train.")){
				hunger = hunger -2;
				phase +=1;
			}
		}else if(type == "Blood Dragon"){
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			if (GUI.Button(new Rect(20, Screen.height-100, 200, 20), "Hunt for humans.")){
				hunger = hunger -2;
				phase +=1;
			}
		}else{
			GUI.Label (new Rect(20,20, 300, 70),
			           "Week " + phase  + " Type " + type);
			GUI.Label (new Rect(20,50, 300, 80),
			           "Your dragon has become a  " + type  + " and fights admirably in the war against the humans! Congratulations! Keep playing and see if you can discover all the dragons!");
			if (GUI.Button(new Rect(220, Screen.height-60, 190, 20), "Play Again?")){
				Application.LoadLevel("dontreallycare");
			}
		}
	
	}
}
