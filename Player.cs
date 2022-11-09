public class Player
{
    private int score;

    public Player(){
        this.score = 0;
    }

    public int getScore()
    {
        return this.score;
    }

    public void setScore()
    {
        this.score += 1;
    }
}