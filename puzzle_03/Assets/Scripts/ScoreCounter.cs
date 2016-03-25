using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {
	public struct Count {
		public int ignite;
		public int score;
		public int total_score;
	}

	public Count last;
	public Count best;

	public static int QUOTA_SCORE = 1000;
	public GUIStyle guistyle;

	// Use this for initialization
	void Start () {
		this.last.ignite = 0;
		this.last.score = 0;
		this.last.total_score = 0;
		this.guistyle.fontSize = 16;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		int x = 20;
		int y = 50;
		GUI.color = Color.black;
		this.print_value (x + 20, y, "count", this.last.ignite);
		y += 30;
		this.print_value (x + 20, y, "plus", this.last.score);
		y += 30;
		this.print_value (x + 20, y, "score", this.last.total_score);
		y += 30;
	}

	public void print_value(int x, int y, string label, int value) {
		GUI.Label (new Rect (x, y, 100, 20), label, guistyle);
		y += 15;
		GUI.Label (new Rect (x, y, 100, 20), value.ToString (), guistyle);
		y += 15;
	}

	public void addIgniteCount(int count) {
		this.last.ignite += count;
		this.update_score ();
	}

	public void clearIgniteCount() {
		this.last.ignite = 0;
	}

	public void update_score() {
		this.last.score = this.last.ignite * 10;
	}

	public void updateTotalScore() {
		this.last.total_score += this.last.score;
	}

	public bool isGameClear() {
		bool is_clear = false;
		if(this.last.total_score > QUOTA_SCORE) {
			is_clear = true;
		}
		return(is_clear);
	}
}
