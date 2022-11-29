import { useState, useCallback, useEffect } from 'react'
import Expenses from "./Expenses"
import ExpenseForm from "./ExpenseForm"

function HomePage() {

    const [expenses, setExpenses] = useState("")

    function addExpenseHandler(expense) {
        setExpenses((prevExpenses) => {
            return [expense, ...prevExpenses];
        });
    }

    const fetchExpensesHandler = useCallback(async () => {
        try {
            const response = await fetch('https://localhost:5001/api/Item'); 
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
            <ExpenseForm onAddExpense={addExpenseHandler} />
            <Expenses expenses={expenses} />
        </div>
    )
}

export default HomePage