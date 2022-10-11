import ExpenseForm from "./components/ExpenseForm"
import Expenses from "./components/Expenses"
import { useState, useEffect, useCallback } from 'react'


function App() {
    const [expenses, setExpenses] = useState("")

    function addExpenseHandler(expense) {
        setExpenses((prevExpenses) => {
            return [expense, ...prevExpenses];
        });
    }

    const fetchExpensesHandler = useCallback(async () => {
        try {
            const response = await fetch('https://localhost:7267/api/Item');
            if (!response.ok) {
                throw new Error('Something went wrong!');
            }

            const data = await response.json();

            const transformedExpenses = data.map((expenseData) => {
                return {
                    id: expenseData.id,
                    title: expenseData.title,
                    amount: expenseData.amount,
                    date: expenseData.date,
                };
            });
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