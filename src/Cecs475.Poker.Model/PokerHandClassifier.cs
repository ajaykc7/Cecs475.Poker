using Cecs475.War;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cecs475.Poker.Cards
{
    public class PokerHandClassifier
    {
        private static List<Card> mHand;

        public static PokerHand ClassifyHand(IEnumerable<Card> hand)
        {
            mHand = new List<Card>(hand);
            SortHand();
            int handType = DetermineHandType(); 
            return new PokerHand(mHand, (PokerHand.HandType)handType);
        }

        private static void  SortHand()
        {
            QuickSort(mHand, 0, mHand.Count-1);
        }

        private static void QuickSort(List<Card> list, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(list, start, end);
                QuickSort(list, start, partitionIndex - 1);
                QuickSort(list, partitionIndex + 1, end);
            }
        }

        private static int Partition(List<Card> list, int start, int end)
        {
            Card pivot = list[end];
            int partitionIndex = start;

            for(int i = start; i < end; i++)
            {
                if (list[i].CompareTo(pivot) > 0)
                {
                    Card temp = list[i];
                    list[i] = list[partitionIndex];
                    list[partitionIndex] = temp;
                    partitionIndex++;
                }

            }
            Card tempTwo = list[partitionIndex];
            list[partitionIndex] = list[end];
            list[end] = tempTwo;
            return partitionIndex;
        }
        
        private static int DetermineHandType()
        {
            if (IsFourKind())
            {
                return 7;
            }else if (IsFullHouse())
            {
                return 6;
            }else if ((IsThreeKind(0))|| (IsThreeKind(1))|| (IsThreeKind(2)))
            {
                return 3;
            }else if(IsTwoPair())
            {
                return 2;
            }else if((HasPair(0)) || (HasPair(1)) || (HasPair(2)) || (HasPair(3)))
            {
                return 1;
            }
            else
            {
                if (IsStraight())
                {
                    if (IsFlush())
                    {
                        if (mHand[0].Kind.ToString().Equals("Ace"))
                        {
                            return 9;
                        }
                        else
                        {
                            return 8;
                        }
                    }
                    else
                    {
                        return 4;
                    }
                }
                else if (IsFlush())
                {
                    return 5;
                }
                else
                {
                    return 0;
                }
            }

            
        }

        private static bool IsStraight()
        {
            int lowCard = 0;
            int highCard = 0;
            if (mHand[0].Kind.ToString().Equals("Ace"))
            {
                lowCard = 1;
                highCard = (int)mHand[1].Kind;
            }
            else
            {
                lowCard = (int)mHand[4].Kind;
                highCard = (int)mHand[0].Kind;
            }

            if (highCard - lowCard == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsFlush()
        {
            string suitType = mHand[0].Suit.ToString();
            for (int i=1; i < mHand.Count; i++)
            {
                if (suitType.Equals(mHand[i].Suit.ToString()))
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsFourKind()
        {
            if((mHand[0].Kind.ToString().Equals(mHand[3].Kind.ToString()))|| (mHand[1].Kind.ToString().Equals(mHand[4].Kind.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsFullHouse()
        {
            if((IsThreeKind(0)))
            {
                if((HasPair(3)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((IsThreeKind(2)))
            {
                if ((HasPair(0)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static bool IsThreeKind(int index)
        {
            if ((mHand[index].Kind.ToString().Equals(mHand[index+2].Kind.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsTwoPair()
        {
            if (((mHand[0].Kind.ToString().Equals(mHand[1].Kind.ToString())) && ((mHand[2].Kind.ToString().Equals(mHand[3].Kind.ToString())))) ||
               ((mHand[0].Kind.ToString().Equals(mHand[1].Kind.ToString())) && ((mHand[3].Kind.ToString().Equals(mHand[4].Kind.ToString())))) ||
               ((mHand[1].Kind.ToString().Equals(mHand[2].Kind.ToString())) && ((mHand[3].Kind.ToString().Equals(mHand[4].Kind.ToString())))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool HasPair(int index)
        {
            /*for(int i =0; i < list.Count - 1; i++)
            {
                if (list[i].Kind.ToString().Equals(list[i + 1].Kind.ToString()))
                {
                    return true;
                } 
            }
            return false;*/

            if (mHand[index].Kind.ToString().Equals(mHand[index + 1].Kind.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void printHand()
        {
            foreach (Card c in mHand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        
    }
}
