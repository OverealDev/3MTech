

import { useState, useEffect, useCallback } from 'react'
import HomePage from "./components/HomePage";
import Login from "./components/Login"


function App() {
    

    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [userId, setUserId] = useState()


    function loginHandler(email, password, id) {
        setIsLoggedIn(true)
        setUserId(id)
        console.log(id)
        console.log(email)
    }

    return (
        <div>
            {!isLoggedIn && <Login onLogin={loginHandler} />}
            {isLoggedIn && <HomePage id={userId} />}
        </div>
    )
} 

export default App;