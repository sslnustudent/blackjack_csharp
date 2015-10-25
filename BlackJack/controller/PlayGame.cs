using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.CardDealtObserver
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
          //  a_game.RegisterSubscriber(this);
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            view.MenuEvent input = a_view.GetInput();

            if (input == view.MenuEvent.play)
            {
                a_game.NewGame();
            }
            else if (input == view.MenuEvent.hit)
            {
                a_game.RegisterSubscriber(this, false);
                a_game.Hit();
                a_game.RemoveSubscriber(this);

            }
            else if (input == view.MenuEvent.stand)
            {
                while (a_game.IsGameOver() == false)
                {
                     a_game.RegisterSubscriber(this, true);
                     a_game.Stand();

                     a_view.DisplayWelcomeMessage();

                     a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
                     a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
                     a_game.RemoveSubscriber(this);
                }
            }

            return input != view.MenuEvent.quit;
        }

        public void CardDealt()
        {
            System.Threading.Thread.Sleep(1500);
        }
    }
}
