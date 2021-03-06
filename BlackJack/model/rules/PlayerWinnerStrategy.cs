﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinnerStrategy : IWinnerStrategy
    {
        public bool IsDealerWinner(Dealer a_dealer, Player a_player, int a_maxScore)
        {
            if (a_player.CalcScore() > a_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > a_maxScore)
            {
                return false;
            }
            else if (a_dealer.CalcScore() == a_player.CalcScore())
            {
                return false;
            }
            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}
