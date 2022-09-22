import './Expenses.css'
import ExpensesList from "./ExpensesList"

function Expenses(props) {
    return (
        <div className="expenses" >
            <ExpensesList expenses={props.expenses} />
        </div>
    );
}

export default Expenses;