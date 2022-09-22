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

    function submitHandler(event) {
        event.preventDefault();

        const expenseData = {
            title: enteredTitle,
            amount: +enteredAmount,
            date: new Date(enteredDate),
            type: enteredType,
            id: Math.random().toString()
        };

        props.onAddExpense(expenseData);

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
                            <option value="books">Books</option>
                            <option value="food">Food</option>
                            <option value="cleaning_stuff">Cleaning stuff</option>
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