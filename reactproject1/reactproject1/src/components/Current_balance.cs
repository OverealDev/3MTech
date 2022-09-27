using System;
import './ExpensesList.js';



public class Current_balance
{
	public double totalAmount = 0;
	public Current_balance()
	{
		for (expenses in expensesList)
		{
            this.totalAmount += expenses
        }
	}
}



