

import { useState, useEffect, useCallback } from 'react'
import HomePage from "./components/HomePage";
import Login from "./components/Login"


function App() {
    

    const [isLoggedIn, setIsLoggedIn] = useState(false);


    function loginHandler() {
        setIsLoggedIn(true)
    }

    return (
        <div>
            {!isLoggedIn && <Login onLogin={loginHandler} />}
            {isLoggedIn && <HomePage />}
        </div>
    )
} 

export default App;