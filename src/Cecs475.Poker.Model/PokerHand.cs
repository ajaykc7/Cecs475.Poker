using Cecs475.War;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cecs475.Poker.Cards
{
    public class PokerHand: IComparable<PokerHand>
    {
        public enum HandType
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfKind,
            Straight,
            Flush,
            FullHouse,
            FourOfKind,
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
                SortHand();
                return mHand;
            }
        }

        public HandType PokerHandType
        {
            get
            {
                return mHType;
            }
        }

        private void SortHand()
        {
            QuickSort(mHand, 0, mHand.Count-1);
        }

        private void QuickSort(List<Card> h, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(h, start, end);
                QuickSort(h, start, partitionIndex - 1);
                QuickSort(h, partitionIndex + 1, end);
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
            if (this.PokerHandType > other.PokerHandType)
            {
                return 1;
            }else if(this.PokerHandType < other.PokerHandType)
            {
                return -1;
            }
            else
            {
                for (int i = this.Hand.Count-1; i >= 0; i--)
                {
                    if (this.Hand[i].CompareTo(other.Hand[i])>0)
                    {
                        return 1;
                    }else if (this.Hand[i].CompareTo(other.Hand[i]) < 0)
                    {
                        return -1;
                    }
                }
                return 0;
            }
        }
    }
}
