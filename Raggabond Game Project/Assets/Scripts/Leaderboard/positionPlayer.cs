
public class positionPlayer {


	private string playerName;
	private int score;


	public positionPlayer (string PlayerName, int Score)
	{
		playerName = PlayerName;
		score = Score;
	}


	public string PlayerName {
		get {
			return playerName;
		}
	}

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
		}
	}

}
