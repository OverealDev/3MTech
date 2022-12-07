

import { useState, useEffect, useCallback } from 'react'
import HomePage from "./components/HomePage";
import Login from "./components/Login"
import Register from "./components/Register"


function App() {
    

    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [userId, setUserId] = useState()
    const [register, setRegister] = useState()


    function loginHandler(email, password, id) {
        setIsLoggedIn(true)
        setUserId(id)
        console.log(id)
        console.log(email)
    }

    function registerHandler() {
        setRegister(true)
    }

    function wantsLoginHandler() {
        setRegister(false)
    }

    return (
        <div>
            {!isLoggedIn && !register && <Login onLogin={loginHandler} onRegister={registerHandler} />}
            {!isLoggedIn && register && <Register onWantsLogin={wantsLoginHandler} />}
            {isLoggedIn && <HomePage id={userId} />}
        </div>
    )
} 

export default App;