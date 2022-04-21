/* CREATE AND COMPARE POKER HANDS
 *
 * Create a new Pokerhand like: PokerHand pokerHand = new Pokerhand("2S 4S 8H JH TC");
 * Values: 2 - 9, T .. Ten, J .. Jack, Q .. Queen, K .. King, A .. Ace
 * Types: S .. Spades, H .. Heart, C .. Clubs, D .. Diamonds
 * Compare this Pokerhand with others like pokerHand.CompareWith(otherHand);
 * Will give an int result as following: -2 .. this hand invalid, -1 .. loss, 0 .. tie, 1 .. win, 2 .. other hand invalid
 */

public class PokerHand
{
    private bool handValid = false;
    private int cardValue = 0; // Highest card
    private int secondaryValue = 0; // In case of two pairs
    private int[] remainingValues;
    private int handValue = 0; /* 0 .. highcard, 1 .. pair, 2 .. two pairs, 3 .. three of a kind, 4 .. straight, 5 .. flush
                            * 6 .. full house, 7 .. four of a kind, 8 .. straight flush, 9 .. royal flush*/


    public PokerHand(string hand)
    {
        // Validate Inputs
        if (hand.Split(' ').Count() != 5) return;
        if (hand.Split(' ').Where(s => s.Length != 2).Count() > 0) return;

        char[] types = hand.Split(' ').Select(s => s[1]).ToArray();
        int[] values = hand.Split(' ').Select(s =>
        {
            s = s[0].ToString();
            s = s.Replace("T", "10");
            s = s.Replace("J", "11");
            s = s.Replace("Q", "12");
            s = s.Replace("K", "13");
            s = s.Replace("A", "14");
            int.TryParse(s, out int result);
            return result;
        }).OrderBy(v => v).ToArray();

        // Validate Inputs
        if (values.Contains(0) || values.Contains(1)) return;
        if (types.Where(t => t != 'S' && t != 'H' && t != 'D' && t != 'C').Count() != 0) return;

        // Pairs
        if (values.Count() != values.Distinct().Count())
        {
            int[] twice = new int[2];
            int thrice = 0;
            foreach(int v in values)
            {
                int multiple = Array.FindAll(values, x => x == v).Count();

                if (multiple == 2)
                {
                    if (twice[0] == 0) twice[0] = v;
                    else if(twice[0] != v) twice[1] = v;
                }
                else if (multiple == 3) thrice = v;
                else if (multiple == 4)
                {
                    // Four of a kind
                    cardValue = v;
                    handValue = 7;
                    break;
                }
            }

            if (thrice == 0 && twice[0] != 0)
            {
                // One or two pairs
                handValue = twice[1] != 0 ? 2 : 1;
                cardValue = twice[1] > twice[0] ? twice[1] : twice[0];
                secondaryValue = twice[1] > twice[0] ? twice[0] : twice[1];
            }
            else if (thrice != 0)
            {
                // Three of a kind with or without a pair
                handValue = twice[0] != 0 ? 6 : 3;
                cardValue = thrice;
                secondaryValue = twice[0];
            }
        }

        // Straight
        if(values[0] + 1 == values[1] && values[1] + 1 == values[2] && values[2] + 1 == values[3] && values[3] + 1 == values[4])
        {
            handValue = 4;
            cardValue = values[4];
        }

        // Flush
        if (types.Skip(1).All(c => c == types[0]))
        {
            cardValue = values[4];

            if (handValue < 4) handValue = 5;
            else if(handValue == 4)
            {
                // Straight or royal flush
                handValue = cardValue == 14 ? 9 : 8;
            }
        }

        remainingValues = values.Where(v => v != cardValue && v != secondaryValue).OrderBy(v => v).ToArray();
        handValid = true;
    }

    public int CompareWith(PokerHand other) // Result: -2 .. this hand invalid, -1 .. loss, 0 .. tie, 1 .. win, 2 .. other hand invalid
    {
        if (!handValid) return -2;
        if (!other.handValid) return 2;

        if (handValue != other.handValue) return handValue > other.handValue ? 1 : -1;
        else if (cardValue != other.cardValue) return cardValue > other.cardValue ? 1 : -1;
        else if (secondaryValue != other.secondaryValue) return secondaryValue > other.secondaryValue ? 1 : -1;
        else
        {
            // Compare remaining cards
            for(int i = remainingValues.Length - 1; i >= 0; i--)
            {
                if (remainingValues[i] != other.remainingValues[i]) return remainingValues[i] > other.remainingValues[i] ? 1 : -1;
            }
        }

        return 0;
    }
}
