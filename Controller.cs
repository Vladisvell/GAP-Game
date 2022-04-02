using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaym
{
    static public class Controller
    {
		private static System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();

		static int increment = 0;
		static int rubasosi = 0;
		static int cost = 20;
		static int zavods = 0;

		static public void RunLogic(GameForm form)
        {
			var kekButton = form.GetKekButton();
			var buyZavod = form.GetBuyZavod();
			var zavodCount = form.GetZavodCount();
			var zavodCost = form.GetZavodCost();

			zavodCount.Text = "Заводов: " + zavods.ToString();
			zavodCost.Text = "Стоимость нового завода: " + cost.ToString() + " рубасосов";

			aTimer.Interval = 1000;
			aTimer.Tick += (sender, args) => rubasosi += increment;
			aTimer.Tick += (sender, args) => kekButton.Text = rubasosi.ToString() + " рубасов";
			aTimer.Tick += (sender, args) => buyZavod.Text = "Купить завод";
			aTimer.Start();

			kekButton.Click += (sender, args) => rubasosi++;
			kekButton.Click += (sender, args) => kekButton.Text = (rubasosi).ToString() + " рубасов";
			buyZavod.Click += (sender, args) =>
			{
				if (rubasosi >= cost)
				{
					zavods++;
					increment++;
					rubasosi -= cost;
					cost *= 2;
					zavodCount.Text = "Заводов: " + zavods.ToString();
					zavodCost.Text = "Стоимость нового завода: " + cost.ToString() + " рубасосов";
				}
				else
				{
					form.NoMoneySound();
				}
			};

		}
    }
}
