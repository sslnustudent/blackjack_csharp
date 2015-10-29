using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.CardDealtObserver
    {
        private model.Game c_game;
        private view.IView c_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            c_game = a_game;
            c_view = a_view;
        }

        public bool Play()
        {
          //  a_game.RegisterSubscriber(this);
            c_view.DisplayWelcomeMessage();

            c_view.DisplayDealerHand(c_game.GetDealerHand(), c_game.GetDealerScore());
            c_view.DisplayPlayerHand(c_game.GetPlayerHand(), c_game.GetPlayerScore());

            if (c_game.IsGameOver())
            {
                c_view.DisplayGameOver(c_game.IsDealerWinner());
            }

            view.MenuEvent input = c_view.GetInput();

            if (input == view.MenuEvent.play)
            {
                c_game.RegisterSubscriber(this, false);
                c_game.RegisterSubscriber(this, true);
                c_game.NewGame();
                c_game.RemoveSubscriber(this);
            }
            else if (input == view.MenuEvent.hit)
            {
                c_game.RegisterSubscriber(this, false);
                c_game.Hit();
                c_game.RemoveSubscriber(this);

            }
            else if (input == view.MenuEvent.stand)
            {
                c_game.RegisterSubscriber(this, true);
                c_game.Stand();
                c_game.RemoveSubscriber(this);
                
            }

            return input != view.MenuEvent.quit;
        }

        public void CardDealt()
        {
            System.Threading.Thread.Sleep(1500);
            c_view.DisplayWelcomeMessage();

            c_view.DisplayDealerHand(c_game.GetDealerHand(), c_game.GetDealerScore());
            c_view.DisplayPlayerHand(c_game.GetPlayerHand(), c_game.GetPlayerScore());
        }
    }
}
