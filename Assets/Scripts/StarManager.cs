using UnityEngine;
using System.Collections.Generic;

public class StarManager : MonoBehaviour {

	public TextAsset csvData;
	public List<Star> starData = new List<Star>();
	public int amountOfStars = 10000;
	public GameObject prefabStar;

	void Start () {
		if(!csvData)
			Debug.LogError("Insert csv file");
			
		ParseFile();
		CreateStars();
	}
	
	void ParseFile () {
		string [] lines = csvData.text.Split('\n');
		bool firstLineRead = false;
		foreach(string line in lines){
			if(!firstLineRead){
				firstLineRead = true;
				continue;
			}
			
			string [] starLine = line.Split(',');
			
			Star star = new Star();
			star.starName = starLine[3];
			star.distance = float.Parse(starLine[12]);
			star.position = new Vector3(float.Parse(starLine[13]), float.Parse(starLine[14]), float.Parse(starLine[15]));
			star.absoluteMagnitude = float.Parse(starLine[16]);
			
			starData.Add(star);
		}
		
		starData.Sort((a,b) => a.relativeMagnitude.CompareTo(b.relativeMagnitude));
	}
	
	void CreateStars(){
		int starsRendered = 0;
		
		while(starsRendered < amountOfStars){
			GameObject star = Instantiate(prefabStar, starData[starsRendered].position, Quaternion.identity) as GameObject;
			star.name = starData[starsRendered].starName;
			Vector3 direction = star.transform.position - Camera.main.transform.position;
			star.transform.rotation = Quaternion.LookRotation(direction);
			starsRendered++;
		}
	
	}
}
