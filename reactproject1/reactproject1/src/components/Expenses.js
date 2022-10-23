import './Expenses.css'
import { useState } from "react"
import ExpensesList from "./ExpensesList"
import ExpensesFilter from "./ExpensesFilter"

function Expenses(props) {
    const [filteredYear, setFilteredYear] = useState("2022");

    function filterChangeHandler(selectedYear) {
        setFilteredYear(selectedYear);
    }

    const filteredExpenses = props.expenses != [] ?
        props.expenses.filter((expense) => {
        return expense.date.getFullYear().toString() === filteredYear;
        })
    :
    []


    return (
        <div className="expenses" >
            <ExpensesFilter
                selected={filteredYear}
                onChangeFilter={filterChangeHandler}
            />
            <ExpensesList expenses={filteredExpenses} />
        </div>
    );
}

export default Expenses;