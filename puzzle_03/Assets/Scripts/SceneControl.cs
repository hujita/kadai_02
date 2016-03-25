using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {
	private BlockRoot block_root = null;
	private ScoreCounter score_counter = null;

	public enum STEP {
		NONE = -1,
		PLAY = 0,
		CLEAR,
		NUM,
	};

	public STEP step = STEP.NONE;
	public STEP next_step = STEP.NONE;
	public float step_timer = 0.0f;
	private float clear_time = 0.0f;
	public GUIStyle guistyle;


	// Use this for initialization
	void Start () {
		this.block_root = this.gameObject.GetComponent<BlockRoot> ();
		this.block_root.initialSetUp ();

		this.score_counter = this.gameObject.GetComponent<ScoreCounter> ();
		this.next_step = STEP.PLAY;
		this.guistyle.fontSize = 24;
	}
	
	// Update is called once per frame
	void Update () {
		this.step_timer += Time.deltaTime;

		if (this.next_step == STEP.NONE) {
			switch (this.step) {
			case STEP.PLAY:
				if (this.score_counter.isGameClear ()) {
					this.next_step = STEP.CLEAR;
				}
				break;
			}
		}

		while (this.next_step != STEP.NONE) {
			this.step = this.next_step;
			this.next_step = STEP.NONE;
			switch (this.step) {
			case STEP.CLEAR:
				this.block_root.enabled = false;
				this.clear_time = this.step_timer;
				break;
			}
			this.step_timer = 0.0f;
		}
	}

	void OnGUI() {
		switch(this.step) {
		case STEP.PLAY:
			GUI.color = Color.black;
			GUI.Label(new Rect(40.0f, 10.0f, 200.0f, 20.0f), "time" + Mathf.CeilToInt(this.step_timer).ToString () + "seconds", guistyle);
			GUI.color = Color.white;
			break;

		case STEP.CLEAR:
			GUI.color = Color.black;
			GUI.Label(new Rect(Screen.width/2.0f - 80.0f, 20.0f, 200.0f, 20.0f), "clear!!", guistyle);
			GUI.Label(new Rect(Screen.width/2.0f - 80.0f, 40.0f, 200.0f, 20.0f), "clear_time" + Mathf.CeilToInt(this.clear_time).ToString () + "seconds", guistyle);
			GUI.color = Color.white;
			break;
		}
	}
}
