using UnityEngine;
using System.Collections;
using System;

public class Score : IComparable<Score> {
	public int Value;
	public string Name;

	public Score (string name, int value) {
		this.Name = name;
		this.Value = value;
	}

	public int CompareTo(Score other) {
		return Value.CompareTo(other.Value);
	}
}