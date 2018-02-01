using Cecs475.War;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cecs475.Poker.Cards
{
    class PokerHand: IComparable<PokerHand>
    {
        public enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        private List<Card> mHand;
        private HandType mHType;

        public PokerHand(List<Card> hand, HandType hType)
        {
            mHand = new List<Card>(hand);
            mHType = hType;

        }

        public List<Card> Hand
        {
            get
            {
                sortHand();
                return mHand;
            }
        }

        public HandType HType
        {
            get
            {
                return mHType;
            }
        }

        private void sortHand()
        {
            quickSort(mHand, 0, mHand.Count);
        }

        private void quickSort(List<Card> h, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(h, start, end);
                quickSort(h, start, partitionIndex - 1);
                quickSort(h, partitionIndex + 1, end);
            }
        }

        private int Partition(List<Card> h, int start, int end)
        {
            Card pivot = h[end];
            int partitionIndex = start;
            for (int i = start; i < end; i++)
            {
                if (h[i].CompareTo(pivot) > 0)
                {
                    Card temp = h[i];
                    h[i] = h[partitionIndex];
                    h[partitionIndex] = temp;
                    partitionIndex++;

                }
            }
            Card tempTwo = h[partitionIndex];
            h[partitionIndex] = h[end];
            h[end] = tempTwo;
            return partitionIndex;
        }

        public int CompareTo(PokerHand other)
        {
            throw new NotImplementedException();
        }
    }
}
