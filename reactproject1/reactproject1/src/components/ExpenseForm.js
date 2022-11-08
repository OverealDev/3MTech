import { useState } from 'react'
import './ExpenseForm.css'

function ExpenseForm(props) {
    const [enteredTitle, setEnteredTitle] = useState("");
    const [enteredAmount, setEnteredAmount] = useState("");
    const [enteredDate, setEnteredDate] = useState("");
    const [enteredType, setEnteredType] = useState("");

    function titleChangeHandler(event) {
        setEnteredTitle(event.target.value);
    }

    function amountChangeHandler(event) {
        setEnteredAmount(event.target.value);
    }

    function dateChangeHandler(event) {
        setEnteredDate(event.target.value);
    }

    function typeChangeHandler(event) {
        setEnteredType(event.target.value);
    }

    async function submitHandler(event) {
        event.preventDefault();

        const expenseData = {
            id: Math.floor(Math.random() * 1000) + 1,
            title: enteredTitle,
            amount: +enteredAmount,
            date: new Date(enteredDate),
            type: 1,
            
        };
        const expenseData2 = {
            title: enteredTitle,
            amount: +enteredAmount,
            date: new Date(enteredDate),
            type: 1,

        };


        props.onAddExpense(expenseData);

        const url = 'http://localhost:5267/api/Item'

        const expense = JSON.stringify(expenseData2)

        console.log(expense)

        const response = await fetch(url, { method: 'POST', body: expense, headers: { 'Content-Type': 'application/json' } })

        const data = await response.json()

        
        setEnteredTitle('');
        setEnteredAmount('');
        setEnteredDate('');
    }

    function cancelHandler() {
        setEnteredTitle('');
        setEnteredAmount('');
        setEnteredDate('');
    }

    return (
        <div className="expense-form">
            <form onSubmit={submitHandler}>
                <div className="expense-form__controls">
                    <div className="expense-form__control">
                        <label>Title</label>
                        <input type="text" onChange={titleChangeHandler} value={enteredTitle} />
                    </div>
                    <div className="expense-form__control">
                        <label>Amount</label>
                        <input
                            type="number"
                            min="0.01"
                            step="0.01"
                            onChange={amountChangeHandler}
                            value={enteredAmount}
                        />
                    </div>
                    <div className="expense-form__control">
                        <label>Date</label>
                        <input
                            type="date"
                            min="2019-01-01"
                            max="2023-12-31"
                            onChange={dateChangeHandler}
                            value={enteredDate}
                        />
                    </div>
                    <div className="expense-form__control">
                        <label>Type</label>
                        <select onChange={typeChangeHandler} value={enteredType}>
                            <option value="1">Books</option>
                            <option value="2">Food</option>
                            <option value="3">Cleaning stuff</option>
                        </select>

                    </div>
                </div>
                <div className="expense-form__actions">
                    <button type="button" onClick={cancelHandler}>Cancel</button>
                    <button type="submit">Add Expense</button>
                </div>
            </form>
        </div>
    )
}

export default ExpenseForm