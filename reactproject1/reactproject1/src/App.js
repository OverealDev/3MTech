import ExpenseForm from "./components/ExpenseForm"
import Expenses from "./components/Expenses"
import { useState } from 'react'

function App() {
    const [expenses, setExpenses] = useState([])

    function addExpenseHandler(expense) {
        setExpenses((prevExpenses) => {
            return [expense, ...prevExpenses];
        });
    }

    return (
        <div>
            <ExpenseForm onAddExpense={addExpenseHandler}/>
            <Expenses expenses={expenses} />
        </div>
    )
} 

export default App;