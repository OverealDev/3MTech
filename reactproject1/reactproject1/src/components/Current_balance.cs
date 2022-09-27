using System;
using System.ComponentModel;

import './ExpensesList.js';



public class Current_balance
{
	public float totalAmount = 0;
	public String currency; """ Euro, Dollar, ..."""

	public Current_balance(String currency_, Item[] itemList ) """ The Item class msut be defined"""
	{

		this.currency = currency_

		for (item in itemList)
		{
			if (currency == item.currency) {

				this.totalAmount += item.price

				}
        }

		this.totalAmount (float)System.Math.Round(value, 2); """Because the smallest unit is the cent"""
 
	}
}
