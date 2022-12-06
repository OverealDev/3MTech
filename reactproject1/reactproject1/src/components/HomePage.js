import { useState, useCallback, useEffect } from 'react'
import Expenses from "./Expenses"
import ExpenseForm from "./ExpenseForm"

function HomePage(props) {

    const [expenses, setExpenses] = useState("")

    function addExpenseHandler(expense) {
        setExpenses((prevExpenses) => {
            return [expense, ...prevExpenses];
        });
    }

    const fetchExpensesHandler = useCallback(async () => {
        try {
            const response = await fetch('http://localhost:5267/api/Item/getuseritems?userid=' + props.id); 
            //if (!response.ok) {
            //    throw new Error('Something went wrong!');
            //}
            console.log(props.id)
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
            <ExpenseForm onAddExpense={addExpenseHandler} id={props.id} />
            <Expenses expenses={expenses}  />
        </div>
    )
}

export default HomePage