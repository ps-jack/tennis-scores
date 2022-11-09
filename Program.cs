/*
    REQUIREMENTS 
    You can read more about Tennis scores on wikipedia which is summarized below:

    You need only report the score for the current game. Sets and Matches are out of scope.

*/


using System;

namespace Program
{
    class Program {
        static void Main(string[] args)
        {
            // Testing
            Player playerOne = new Player();
            Player playerTwo = new Player();

            while (determineWinner(playerOne, playerTwo) == null) {
                Console.WriteLine("Current Score : " + getCurrScore(playerOne,playerTwo));
                Console.WriteLine("Who's won the point :");
                string input = Console.ReadLine();
                if (checkInput(input) == 1) {
                    playerOne.setScore();
                }
                else if (checkInput(input) == 2) {
                    playerTwo.setScore();
                } else {
                    Console.WriteLine("Invalid input");
                }
            }
            Console.WriteLine("Winner : " + determineWinner(playerOne, playerTwo));
        }

        // Checking input given by the user.
        private static int checkInput(string inputs) {
            if (inputs == "1") {
                return 1;
            }
            else if (inputs == "2") {
                return 2;
            }
            else {
                return 0;
            }
        }

        /*
            A game is won by the first player to have won at least four points in total and at least two points more than the opponent.
        */
        private static string determineWinner(Player one, Player two)
        {
            int oneScore = one.getScore();
            int twoScore = two.getScore();

            if (oneScore >= 4 || twoScore >= 4)
            {
                if (oneScore - twoScore >= 2)
                    return "one";

                else if (twoScore - oneScore >= 2) 
                    return "two";
            }

            return null;
        }
        // The running score of each game is described in a manner peculiar to tennis: scores from zero to three points are described as “Love”, “Fifteen”, “Thirty”, and “Forty” respectively.

        private static string getCurrScore (Player one, Player two) {
            int oneScore = one.getScore();
            int twoScore = two.getScore();
            string score;
            string[] scoreArray = {"Love", "Fifteen", "Thirty", "Forty"};
            if (isDeuce(one, two)) {
                score = "Deuce";
            }
            else if (isAdvantage(one, two) != null) {
                score = isAdvantage(one, two);
            }
            else {
                score = "Player 1 : " + scoreArray[oneScore] + " Player 2 : " + scoreArray[twoScore];
            }
            

            return score;
        }

        /* 
            If at least three points have been scored by each player, and the scores are equal, the score is “Deuce”. 
        */
        private static bool isDeuce(Player one, Player two){
            int oneScore = one.getScore();
            int twoScore = two.getScore();

            if (oneScore >= 3 && twoScore >= 3)
            {
                if (oneScore == twoScore)
                    return true;
            }
            return false;
        }

        // If at least three points have been scored by each side and a player has one more point than his opponent, the score of the game is “Advantage” for the player in the lead.
        private static string isAdvantage(Player one, Player two){
            int oneScore = one.getScore();
            int twoScore = two.getScore();

            if (oneScore >= 3 && twoScore >= 3)
            {
                if ((oneScore - twoScore) == 1)
                    return "Advantage to Player 1";
                if ((twoScore - oneScore) == 1)
                    return "Advantage to Player 2";
            }
            return null;
        }
    }
}
    
