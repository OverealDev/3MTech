import React, { useState, useEffect } from 'react';
import './Register.css';


const Register = (props) => {
    const [enteredEmail, setEnteredEmail] = useState('');
    const [emailIsValid, setEmailIsValid] = useState();
    const [enteredPassword, setEnteredPassword] = useState('');
    const [passwordIsValid, setPasswordIsValid] = useState();
    const [formIsValid, setFormIsValid] = useState(false);
    const [userId, setUserId] = useState()
    const [register, setRegister] = useState()
    const [wrong, setWrong] = useState()

    useEffect(() => {
        const identifier = setTimeout(() => {
            setFormIsValid(
                enteredEmail.includes('@') && enteredPassword.trim().length > 6
            );
        }, 500)

        return () => { clearTimeout(identifier) }

    }, [enteredEmail, enteredPassword])

    const emailChangeHandler = (event) => {
        setEnteredEmail(event.target.value);
    };

    const passwordChangeHandler = (event) => {
        setEnteredPassword(event.target.value);
    };

    const validateEmailHandler = () => {
        setEmailIsValid(enteredEmail.includes('@'));
    };

    const validatePasswordHandler = () => {
        setPasswordIsValid(enteredPassword.trim().length > 6);
    };

    const wantsLoginHandler = () => {
        setRegister(true)
        props.onWantsLogin()
    }

    function wrongHandler() {
        setWrong(true)
    }

    async function submitHandler(event){


        fetch('http://localhost:5267/api/User/getuserbyemail?email=' + enteredEmail).then(async function (response) {
            const data = response.json()
            if (!response.ok) {
                // make the promise be rejected if we didn't get a 2xx response
                const userData = {
                    email: enteredEmail,
                    password: enteredPassword
                }
                const url = 'http://localhost:5267/api/User'
                const user = JSON.stringify(userData)


                const response = await fetch(url, { method: 'POST', body: user, headers: { 'Content-Type': 'application/json' } })

                const data = await response.json()

                props.onWantsLogin()
            } else {
                // got the desired response
                console.log("account already exists")
                wrongHandler()
            }
        }).catch(function (err) {
            console.log(err)
        });

        event.preventDefault()


    }









    //};

    return (

        <div>
            <form onSubmit={submitHandler} className="bckgrd">
                <div
                    className="control"

                >
                    <label htmlFor="email">E-Mail</label>
                    <input
                        type="email"
                        id="email"
                        value={enteredEmail}
                        onChange={emailChangeHandler}
                        onBlur={validateEmailHandler}
                    />
                </div>
                <div
                    className="control"
                >
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        id="password"
                        value={enteredPassword}
                        onChange={passwordChangeHandler}
                        onBlur={validatePasswordHandler}
                    />
                </div>
                <div className="actions">
                    <button type="submit" disabled={!formIsValid}>
                        Register
                    </button>
                </div>

            </form>
            {wrong && <p className="wrong">Account already exists</p>}
            <div className="register">
                <p>Already have an account ?</p>
                <button onClick={wantsLoginHandler}>Login</button>
            </div>

        </div>
    );
};

export default Register;
