import ExpenseForm from "./components/ExpenseForm"
import Expenses from "./components/Expenses"
import LoginButton from "./components/LoginButton"

import { useState, useEffect, useCallback } from 'react'


function App() {
    const [expenses, setExpenses, lo] = useState("")

    function addExpenseHandler(expense) {
        setExpenses((prevExpenses) => {
            return [expense, ...prevExpenses];
        });
    }

    const fetchExpensesHandler = useCallback(async () => {
        try {
            const response = await fetch('http://localhost:5267/api/Item');
            //if (!response.ok) {
            //    throw new Error('Something went wrong!');
            //}
            console.log("1")
            const data = await response.json();
            console.log("2")
            const transformedExpenses = data.map((expenseData) => {
                return {
                    id: expenseData.id,
                    title: expenseData.title,
                    amount: expenseData.amount,
                    date: new Date(Date.parse(expenseData.date)),
                };
            });
            console.log(transformedExpenses)
            setExpenses(transformedExpenses);
        } catch (error) {
            console.log(error.message);
        }
    }, []);

    useEffect(() => {
        fetchExpensesHandler();
    }, []);

    return (
        <div>
            <ExpenseForm onAddExpense={addExpenseHandler}/>
            <Expenses expenses={expenses} />
            <LoginButton login-button={lo}/>
        </div>
    )
} 

export default App;